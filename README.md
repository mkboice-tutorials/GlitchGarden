# Unity Setup
## Configure Unity for version control
* Edit > Project Settings > Editor
* Version Control / Mode: "Visible Meta Files"
* Asset Serialization / Mode: "Force Text"

## Configure git lfs
* git install lfs

## Update the git config
```
[mergetool "unity_yaml"]
cmd = '/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
trustExitCode = false
keepTemporaries = true
keepBackup = false
 
[merge]
tool = unity_yaml
```