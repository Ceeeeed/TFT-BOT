using System.Collections.Generic;
using System;

public enum ChampionName { None, Aatrox, Ahri, Akali, Anivia, Ashe, AurelionSol, Blitzcrank, Brand, Braum, ChoGath, Darius, Draven, Elise, Evelynn, Fiora, Gangplank, Garen, Gnar, Graves, Karthus, Kassadin, Katarina, Kayle, Kennen, KhaZix, Kindred, Leona, Lissandra, Lucian, Lulu, MissFortune, Mordekaiser, Morgana, Nidalee, Poppy, Pyke, RekSai, Rengar, Sejuani, Shen, Shyvana, Swain, Tristana, TwistedFate, Varus, Vayne, Veigar, Volibear, Warwick, Yasuo, Zed };
public enum ChampionOrigin { None, Demon, Dragon, Exile, Glacial, Imperial, Ninja, Noble, Phantom, Pirate, Robot, Void, Wild, Yordle };
public enum ChampionClass { None, Assassin, Blademaster, Brawler, Elementalist, Guardian, Gunslinger, Knight, Ranger, Shapeshifter, Sorcerer };

public static class Champions {
    public static List<Champion> allChampions;

    public static Champion allChampionsFindByName(ChampionName n) {
        return allChampions.Find(delegate (Champion c) { return c.name == n; });
    }
}

public struct Champion {
    public ChampionName name;
    public int cost;
    public int tierList;
    public int level;
    public ChampionOrigin originOne;
    public ChampionOrigin originTwo;
    public ChampionClass classOne;
    public ChampionClass classTwo;
    public Item[] preferedItems;
    public int[] prefferedPos;

    public Champion(ChampionName name, int cost, int tierList, int level, ChampionOrigin originOne, ChampionOrigin originTwo, ChampionClass classOne, ChampionClass classTwo, Item[] preferedItems, int[] prefferedPos) {
        this.name = name;
        this.cost = cost;
        this.tierList = tierList;
        this.level = level;
        this.originOne = originOne;
        this.originTwo = originTwo;
        this.classOne = classOne;
        this.classTwo = classTwo;
        this.preferedItems = preferedItems;
        this.prefferedPos = prefferedPos;
    }

    public override string ToString() {
        return $"name: {name},   cost: {cost},   tierList: {tierList},   level: {level},   originOne: {originOne},   originTwo: {originTwo},   classOne: {classOne},   classTwo: {classTwo}";
    }
}

public struct Class {
    public int[] champValue;
    public ChampionClass name;

    public Class(int[] champValue, ChampionClass name) {
        this.champValue = champValue;
        this.name = name;
    }
}

public struct Origin {
    public int[] champValue;
    public ChampionOrigin name;

    public Origin(int[] champValue, ChampionOrigin name) {
        this.champValue = champValue;
        this.name = name;
    }
}
