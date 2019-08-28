using System;
using System.Diagnostics;

public class Manager {
    public static Bitmaps bitmaps;

    public void Start() {
        Champions.allChampions = DataLoader.LoadChampionsData();
        bitmaps = new Bitmaps();
    }

    int round = 0;
    bool run = true;
    Stopwatch mainClock = new Stopwatch();
    Stopwatch sw = new Stopwatch();
    public void Run() {
        sw.Start();
        mainClock.Start();
        while (true) {
            if (mainClock.ElapsedMilliseconds > 30000) {
                ImageFinder.CaptureScreen();
                Info.UpdatePlanning();


                if (Info.planning)
                    NewRound();

            } else if (mainClock.ElapsedMilliseconds > 25000) {
                if (run == true)
                    Pickupable.PickupAll();

                run = false;
            }

            if (run) {
                ImageFinder.CaptureScreen();
                Info.UpdateAll();



            }

            Console.WriteLine($"LowHp: {Info.lowHp}\nMain clock: {mainClock.ElapsedMilliseconds}\nRound: {round}\nGold: {Info.gold}\nExp: {Info.exp}\nLevel: {Info.level}\nCzas skanowania (ms): {sw.ElapsedMilliseconds}\nSklep:\n   {Info.store[0].name}\n   {Info.store[1].name}\n   {Info.store[2].name}\n   {Info.store[3].name}\n   {Info.store[4].name}\n-----------------------");
            sw.Restart();
        }
    }

    public void Reroll() {
        if (Info.lowHp && Info.gold > 6 || Info.gold > 56) {
            AutoIt.AutoItX.Sleep(100);
            AutoIt.AutoItX.Send("d");
            AutoIt.AutoItX.Sleep(100);
        }
    }

    public void NewRound() {
        run = true;
        mainClock.Restart();
        round++;
        AutoIt.AutoItX.Sleep(1000);
    }
}
