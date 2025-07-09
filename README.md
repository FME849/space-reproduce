# Reproduce Guide
## Setup
1. SpacetimeDB: run `spacetime publish --project-path server-rust --server local space-reproduce` at the root of project
2. Generate client script: run `spacetime generate --lang csharp --out-dir './WebGL Build/Assets/Scripts/auto-gen' --project-path ./server-rust` at the root of project

## Build and Run
1. Open `WebGL Build` Unity project
2. Switch to `SpaceReproduce` build profile
3. Run Unity `Build And Run` 

**Note:**
1. This project's purpose is to reproduce the Identity problem which cannot retrieve user's Identity with token from Firebase
2. The Firebase config can be found in WebGL Build/Assets/WebGLTemplates/SpaceReproduce/index.html