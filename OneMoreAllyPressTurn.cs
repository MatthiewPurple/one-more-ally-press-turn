﻿using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using one_more_ally_press_turn;

[assembly: MelonInfo(typeof(OneMoreAllyPressTurn), "One more ally Press Turn", "1.0.0", "Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace one_more_ally_press_turn;
public class OneMoreAllyPressTurn : MelonMod
{
    // After initiating a phase
    [HarmonyPatch(typeof(nbMainProcess), nameof(nbMainProcess.nbSetPressMaePhase))]
    private class Patch
    {
        public static void Postfix()
        {
            short activeunit = nbMainProcess.nbGetMainProcessData().activeunit; // Get the formindex of the first active demon

            // If that demon is an ally and the allies don't already have 8 press turns
            if (activeunit < 4 && nbMainProcess.nbGetMainProcessData().press4_p < 8)
            {
                nbMainProcess.nbGetMainProcessData().press4_p++; // Add 1 full press turn
                nbMainProcess.nbGetMainProcessData().press4_ten++; // Add 1 total press turn
            }
        }
    }
}
