using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public static class DataLoader {
    public static List<Champion> LoadChampionsData() {
        string excelData = File.ReadAllText(@"Data\Champions.csv");
        List<List<string>> strings = TrimString(excelData);

        List<Champion> champions = new List<Champion>();

        for (int i = 1; i < strings.Count; i++) {

            List<string> line = strings[i];

            Enum.TryParse(line[0], out ChampionName name);
            int.TryParse(line[1], out int cost);
            int.TryParse(line[2], out int tierList);
            int level = 0;
            Enum.TryParse(line[3], out ChampionOrigin originOne);
            Enum.TryParse(line[4], out ChampionOrigin originTwo);
            Enum.TryParse(line[5], out ChampionClass classOne);
            Enum.TryParse(line[6], out ChampionClass classTwo);

            Enum.TryParse(line[7], out Item itemOne);
            Enum.TryParse(line[8], out Item itemTwo);
            Enum.TryParse(line[9], out Item itemThree);
            Enum.TryParse(line[10], out Item itemFour);
            Enum.TryParse(line[11], out Item itemFive);
            Enum.TryParse(line[12], out Item itemSix);

            int.TryParse(line[13], out int posOne);
            int.TryParse(line[14], out int posTwo);
            int.TryParse(line[15], out int posThree);
            int.TryParse(line[16], out int posFour);

            champions.Add(new Champion(name, cost, tierList, level, originOne, originTwo, classOne, classTwo, new Item[] { itemOne, itemTwo, itemThree, itemFour, itemFive, itemSix }, new int[] { posOne, posTwo, posThree, posFour }));
        }

        return champions;
    }

    private static List<List<string>> TrimString(string excelData) {
        string[] arr = excelData.Split('\n');
        List<List<string>> list = new List<List<string>>();

        foreach (string s in arr) {
            list.Add(s.Split(',').ToList());
        }

        return list;
    }
}