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
3. Signing/Xcode failures at the very end are fine today — the pipeline is
   the lesson, not the provisioning profile.

## Verify
- `build_status` reaches completed (or fails only at Xcode signing) and the
  BuildReport lists the Init/Main/Level scenes — placed by the preprocessor.

## Done?
`./catchup.sh complete` any time you want the finished workshop state.
