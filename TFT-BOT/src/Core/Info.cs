using System;
using System.Collections.Generic;
using System.Drawing;

public static class Info {
    public static Champion[] store = new Champion[5];
    public static int gold;
    public static int exp;
    public static Point level;
    public static bool planning;
    public static bool lowHp;

    public static void UpdateAll() {
        UpdatePlanning();
        UpdateGold();
        UpdateExp();
        UpdateLevel();
        UpdateStore();
        UpdateHP();
    }

    public static void UpdateGold() {
        List<Bitmap> list = Manager.bitmaps.goldList;

        for (int i = 0; i < list.Count; i++) {
            if (ImageFinder.FindOnScreen(list[i], new Rectangle(875, 888, 27, 17))) {
                gold = i;
                return;
            }
        }

        Console.WriteLine("Nie znaleziono bitmapy z goldem!");
    }

    public static void UpdateExp() {
        List<Bitmap> list = Manager.bitmaps.expList;

        for (int i = 0; i < list.Count; i++) {
            if (ImageFinder.FindOnScreen(list[i], new Rectangle(282, 1044, 31, 24))) {
                exp = i * 2;
                return;
            }
        }

        Console.WriteLine("Nie znaleziono bitmapy z expem!");
    }

    public static void UpdatePlanning() {

        if (ImageFinder.FindOnScreen(Manager.bitmaps.planning, new Rectangle(901, 120, 2, 2))) {
            planning = true;
        } else {
            planning = false;
        }

    }

    public static void UpdateLevel() {
        int e = exp;
        int[] arr = new int[] { 2, 6, 10, 18, 30, 46, 64 };
        Point result = new Point(2, 0);

        for (int i = 0; i < arr.Length; i++) {
            if (e - arr[i] >= 0) {
                e -= arr[i];
                result.X++;
            } else {
                result.Y = e;
                level = result;
                return;
            }
        }
    }

    private readonly static int storeSlotOffset = 201;
    public static void UpdateStore() {
        List<Bitmap> list = Manager.bitmaps.championList;

        for (int s = 0; s < store.Length; s++) {

            Rectangle rect;
            if (s == 0 || s == 1 || s == 2) {
                rect = new Rectangle(613 + storeSlotOffset * s, 958, 25, 25);
            } else {
                rect = new Rectangle(614 + storeSlotOffset * s, 958, 25, 25);
            }

            for (int i = 0; i < list.Count; i++) {
                if (ImageFinder.FindOnScreen(list[i], rect)) {
                    store[s] = Champions.allChampionsFindByName((ChampionName)i);
                    break;
                }
            }
        }

    }

    public static void UpdateHP() {
        if (!lowHp) {
            ImageFinder.FindOnScreen(Manager.bitmaps.hp, new Rectangle(1858, 161, 1, 648), out List<Point> points);
            if (points.Count > 0) {
                Color emptyCol = Color.FromArgb(255, 22, 24, 33);
                if (ImageFinder.screen.GetPixel(points[0].X, points[0].Y + 55) == emptyCol) {
                    lowHp = true;
                }
            }
        }
    }
}
