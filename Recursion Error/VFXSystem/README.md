# Recursion Error - Cybernetic VFX System

## Files

This folder contains code that I wrote for a VFX system for cybernetics (items) in the game Recursion Error. The PlayerController and BattleManager scripts contain the code for the system while the DashShield script shows an example of how the system is used in one of the cybernetic scripts.

## Description

This system checks if the scriptable object for the cybernetic the player picked up has any VFX. If there are VFX they will be added to a dictionary that will be easily accessible in the scripts for the cybernetics. This allows for a simple way to implement the code for playing VFX in the cybernetics scripts. While this system may not be the most efficient, it allowed for cleaner code in our cybernetic scripts and was much faster to implement.
