# Panoply Game Creator 1 Actions
Actions for Game Creator to control Panoply panels

## Requirements
[Game Creator 1](https://assetstore.unity.com/packages/tools/game-toolkits/game-creator-89443) and [Panoply](https://assetstore.unity.com/packages/tools/utilities/panoply-comics-splitscreen-for-unity-58506) are both required.

## Tips
Both Panoply and Game Creator 1 attempt to add Event Systems. This leads to Warnings spam because only one Event System should exist. 

The simplest way to bypass this is to make an empty GameObject named EventSystem which prevents Panoply from instantiating its own EventSystem prefab.
Alternatively, one can manually create GameCreator.Core.EventSystemManager in the editor and rename it to EventSystem to prevent both tools from adding Event Systems.