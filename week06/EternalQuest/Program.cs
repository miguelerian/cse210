using System;

class Program
{
    static void Main(string[] args)
    {
        /*
         * EXCEEDING REQUIREMENTS:
         * 
         * I added two new types of goals to make the program more engaging.
         * The ProgressGoal lets users make gradual progress toward a big goal
         * (like running a marathon), and gives a bonus when it’s completed.
         * 
         * I also added a NegativeGoal, which subtracts points for bad habits.
         * This adds accountability and makes the system feel more realistic.
         * 
         * Overall, these features improve motivation by adding both rewards
         * and consequences, making the program more like a real game.
         */

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}