using System.Collections.Generic;

public static class Builds {
    public struct Build {
        public string buildName;
        public List<ChampionName> name;
        public List<int> position;

        public int GetNumberOfChampionsOnBoard() {
            int i = 0;
            foreach (var c in Board.board) {
                if (name.Contains(c.name)) {
                    if (c.level == 1) {
                        i++;
                    } else if (c.level == 2) {
                        i += 3;
                    } else if (c.level == 3) {
                        i += 9;
                    }
                }
            }
            return i;
        }
    }

    public static bool buildFound;
    public static List<Build> builds;
    public static List<ChampionName> wantedChampions;

    public static void UpdateWantedChampions() {
        List<ChampionName> champs = new List<ChampionName>();

        for (int i = 0; i < builds.Count; i++) {
            for (int j = 0; j < builds[i].name.Count; j++) {
                if (!wantedChampions.Exists(delegate (ChampionName x) { return x == builds[i].name[j]; }))
                    champs.Add(builds[i].name[j]);
            }
        }

        wantedChampions = champs;
    }

    public static void RemoveBuilds() {
        if (!buildFound)
            for (int i = 0; i < 20; i++) {
                for (int j = 0; j < builds.Count; j++) {
                    if (builds[j].GetNumberOfChampionsOnBoard() == 0) {
                        builds.RemoveAt(j);
                    } else if (builds[j].GetNumberOfChampionsOnBoard() == i) {
                        builds.RemoveAt(j);
                        UpdateWantedChampions();
                        Store.SellUnwanted();
                        if (builds.Count == 1)
                            buildFound = true;
                        return;
                    }
                }
            }
    }

}
