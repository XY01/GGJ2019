// ------------------------------------------------------------------------------
//  _______   _____ ___ ___   _   ___ ___ 
// |_   _\ \ / / _ \ __/ __| /_\ | __| __|
//   | |  \ V /|  _/ _|\__ \/ _ \| _|| _| 
//   |_|   |_| |_| |___|___/_/ \_\_| |___|
// 
// This file has been generated automatically by TypeSafe.
// Any changes to this file may be lost when it is regenerated.
// https://www.stompyrobot.uk/tools/typesafe
// 
// TypeSafe Version: 1.3.2-Unity5
// 
// ------------------------------------------------------------------------------



public sealed class SRScenes {
    
    private SRScenes() {
    }
    
    private const string _tsInternal = "1.3.2-Unity5";
    
    public static global::TypeSafe.Scene TitleScreen {
        get {
            return @__all[0];
        }
    }
    
    public static global::TypeSafe.Scene LevelOne {
        get {
            return @__all[1];
        }
    }
    
    public static global::TypeSafe.Scene ScoreScreen {
        get {
            return @__all[2];
        }
    }
    
    public static global::TypeSafe.Scene Master {
        get {
            return @__all[3];
        }
    }
    
    public static global::TypeSafe.Scene Proto_Movement {
        get {
            return @__all[4];
        }
    }
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.Scene> @__all = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.Scene>(new global::TypeSafe.Scene[] {
                new global::TypeSafe.Scene("TitleScreen", 0),
                new global::TypeSafe.Scene("LevelOne", 1),
                new global::TypeSafe.Scene("ScoreScreen", 2),
                new global::TypeSafe.Scene("Master", 3),
                new global::TypeSafe.Scene("Proto Movement", 4)});
    
    public static global::System.Collections.Generic.IList<global::TypeSafe.Scene> All {
        get {
            return @__all;
        }
    }
}
