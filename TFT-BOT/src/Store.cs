using System;
using System.Drawing;
using AutoIt;

public static class Store {

    public static void SellUnwanted() {
        for (int i = 0; i < Board.board.Length; i++)
            if (Board.board[i].name != ChampionName.None && !Builds.wantedChampions.Exists(delegate (ChampionName x) { return x == Board.board[i].name; })) {
                Sell(i);
                Board.board[i].name = ChampionName.None;
            }
    }

    public static void BuyAll() {
        for (int i = 0; i < Info.store.Length; i++)
            if (Builds.wantedChampions.Contains(Info.store[i].name)) {

                Champion[] champs = Array.FindAll(Board.board, x => x.name == Info.store[i].name && Info.store[i].level == 1);
                Champion[] emptyBenchSlots = Array.FindAll(Board.board, x => x.name == ChampionName.None);
                if (champs.Length > 1) { //join
                    ClickBuy(i);
                    Join(Info.store[i].name);
                } else if (emptyBenchSlots.Length > 0) { // default
                    for (int j = 0; j < 9; j++) {
                        if (Board.board[i].name == ChampionName.None) {
                            Board.board[i] = Champions.allChampionsFindByName(Info.store[i].name);
                        }
                    }
                    ClickBuy(i);
                } else { // no space
                    if (!Builds.buildFound)
                        Builds.RemoveBuilds();
                    else
                        continue;
                    if (Builds.wantedChampions.Contains(Info.store[i].name)) {
                        for (int j = 0; j < 9; j++) {
                            if (Board.board[i].name == ChampionName.None) {
                                Board.board[i] = Champions.allChampionsFindByName(Info.store[i].name);
                            }
                        }
                        ClickBuy(i);
                    }
                }
            }
    }

    private static void Join(ChampionName name) {
        int count = 0;
        for (int i = 8; i >= 0; i--) {
            if (Board.board[i].name == name && Board.board[i].level == 1) {
                count++;

                if (count == 2)
                    Board.board[i].level = 2;
                else
                    Board.board[i].name = ChampionName.None;
            }
        }

        for (int i = 29; i >= 9; i--) {
            if (Board.board[i].name == name && Board.board[i].level == 1) {
                count++;

                if (count == 2)
                    Board.board[i].level = 2;
                else
                    Board.board[i].name = ChampionName.None;
            }
        }

        Champion[] champs = Array.FindAll(Board.board, x => x.name == name && x.level == 2);
        if (champs.Length > 2) {
            count = 0;
            for (int i = 8; i >= 0; i--) {
                if (Board.board[i].name == name && Board.board[i].level == 2) {
                    count++;

                    if (count == 3)
                        Board.board[i].level = 3;
                    else
                        Board.board[i].name = ChampionName.None;
                }
            }

            for (int i = 29; i >= 9; i--) {
                if (Board.board[i].name == name && Board.board[i].level == 2) {
                    count++;

                    if (count == 3)
                        Board.board[i].level = 2;
                    else
                        Board.board[i].name = ChampionName.None;
                }
            }

            Builds.wantedChampions.Remove(name);
        }
    }

    private static void ClickBuy(int index) {
        AutoItX.MouseMove(600 + index * 200, 1000, 15);
        AutoItX.MouseDown();
        AutoItX.MouseMove(AutoItX.MouseGetPos().X, AutoItX.MouseGetPos().Y - 200, 15);
        AutoItX.MouseUp();
        Info.store[index].name = ChampionName.None;
    }

    public static void Sell(int index) {
        Point pos = Board.GetPosition(index);
        AutoItX.MouseMove(pos.X, pos.Y, 15);
        AutoItX.Send("e");
    }
}
