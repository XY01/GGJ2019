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



public sealed class SRLayers {
    
    private SRLayers() {
    }
    
    private const string _tsInternal = "1.3.2-Unity5";
    
    public static global::TypeSafe.Layer Default {
        get {
            return @__all[0];
        }
    }
    
    public static global::TypeSafe.Layer TransparentFX {
        get {
            return @__all[1];
        }
    }
    
    public static global::TypeSafe.Layer Ignore_Raycast {
        get {
            return @__all[2];
        }
    }
    
    public static global::TypeSafe.Layer Water {
        get {
            return @__all[3];
        }
    }
    
    public static global::TypeSafe.Layer UI {
        get {
            return @__all[4];
        }
    }
    
    public static global::TypeSafe.Layer PostProcessing {
        get {
            return @__all[5];
        }
    }
    
    public static global::TypeSafe.Layer Terrain {
        get {
            return @__all[6];
        }
    }
    
    public static global::TypeSafe.Layer Echidna {
        get {
            return @__all[7];
        }
    }
    
    public static global::TypeSafe.Layer Interactables {
        get {
            return @__all[8];
        }
    }
    
    public static global::TypeSafe.Layer Players {
        get {
            return @__all[9];
        }
    }
    
    public static global::TypeSafe.Layer PickedUpInteractable {
        get {
            return @__all[10];
        }
    }
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.Layer> @__all = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.Layer>(new global::TypeSafe.Layer[] {
                new global::TypeSafe.Layer("Default", 0),
                new global::TypeSafe.Layer("TransparentFX", 1),
                new global::TypeSafe.Layer("Ignore Raycast", 2),
                new global::TypeSafe.Layer("Water", 4),
                new global::TypeSafe.Layer("UI", 5),
                new global::TypeSafe.Layer("PostProcessing", 8),
                new global::TypeSafe.Layer("Terrain", 9),
                new global::TypeSafe.Layer("Echidna", 10),
                new global::TypeSafe.Layer("Interactables", 11),
                new global::TypeSafe.Layer("Players", 12),
                new global::TypeSafe.Layer("PickedUpInteractable", 13)});
    
    public static global::System.Collections.Generic.IList<global::TypeSafe.Layer> All {
        get {
            return @__all;
        }
    }
}
