# Exercise 09 — Ship It — iOS Build from the Terminal

**Time:** 5 min instructor demo + 10 min hands-on
**Start checkpoint:** `./catchup.sh ex09` (everyone runs this — finished, behind, or absent last round, you all start identical)

## Goal
Build the real game for iOS from the terminal — and meet a production detail:
this repo has a build preprocessor (`LevelList.cs`) that fills Build Settings
with the level scenes automatically. Reading other people's build plumbing IS
the exercise.

## Instructor demo (5 min)
1. Show `BuildLevelList : IPreprocessBuildWithReport` in `LevelList.cs` —
   what will it do to our scene list at build time?
2. Kick the build on the live editor:
   ```
   unity command --project-path . build --target iOS --outputPath Builds/iOS --confirm true
   unity command --project-path . build_status
   ```

## Your turn (10 min)
1. Run the build; poll `build_status` while it works.
2. While waiting, answer in one sentence each (the agent may help, verify in
   source): Which scenes end up in the build, and who put them there?
   What would CI need beyond this command? (service account + license seat)
3. **The build may stop itself once**: if your editor's Build Settings scene
   list has drifted from the LevelList asset (the editor caches that list in
   `Library/`, so a fresh clone usually goes straight through), the
   preprocessor repairs it and throws "Level List had to be rebuilt, restart
   the build". Run the build again — the second attempt goes through. Read
   `BuildLevelList.OnPreprocessBuild` and explain why it stops instead of
   continuing (hint: when does Unity read the scene list for the build?). Bonus: the report also lists ~13 "More than one
   global light" errors — they come from the pipeline package opening every
   scene additively while scanning for RuntimePipelineManager components, and
   the build still succeeds. Would you ship CI on a build that logs errors?
4. Signing/Xcode failures at the very end are fine today — the pipeline is
   the lesson, not the provisioning profile.

## Verify
- `build_status` reaches completed (or fails only at Xcode signing) and the
  BuildReport lists the Init/Main/Level scenes — placed by the preprocessor.

## Done?
`./catchup.sh complete` any time you want the finished workshop state.
