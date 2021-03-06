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



public sealed class SRResources {
    
    private SRResources() {
    }
    
    private const string _tsInternal = "1.3.2-Unity5";
    
    public static global::TypeSafe.Resource<global::UnityEngine.Shader> faceHighlight {
        get {
            return ((global::TypeSafe.Resource<global::UnityEngine.Shader>)(@__ts_internal_resources[0]));
        }
    }
    
    public static global::TypeSafe.Resource<global::UnityEngine.Material> faceMat {
        get {
            return ((global::TypeSafe.Resource<global::UnityEngine.Material>)(@__ts_internal_resources[1]));
        }
    }
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                new global::TypeSafe.Resource<global::UnityEngine.Shader>("faceHighlight", "faceHighlight"),
                new global::TypeSafe.Resource<global::UnityEngine.Material>("faceMat", "faceMat")});
    
    public sealed class Textures {
        
        private Textures() {
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> neutralBGPro {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[0]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> blueChannelBGPro {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[1]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> greenChannelBG {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[2]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> redChannelBG {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[3]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> redChannelBGPro {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[4]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> blueChannelBG {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[5]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> GridBox_Default {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[6]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> greenChannelBGPro {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[7]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> neutralBG {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[8]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> box_bg {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[9]));
            }
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("neutralBGPro", "Textures/neutralBGPro"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("blueChannelBGPro", "Textures/blueChannelBGPro"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("greenChannelBG", "Textures/greenChannelBG"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("redChannelBG", "Textures/redChannelBG"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("redChannelBGPro", "Textures/redChannelBGPro"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("blueChannelBG", "Textures/blueChannelBG"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("GridBox_Default", "Textures/GridBox_Default"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("greenChannelBGPro", "Textures/greenChannelBGPro"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("neutralBG", "Textures/neutralBG"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("box_bg", "Textures/box_bg")});
        
        /// <summary>
        /// Return a list of all resources in this folder.
        /// This method has a very low performance cost, no need to cache the result.
        /// </summary>
        /// <returns>A list of resource objects in this folder.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
            return @__ts_internal_resources;
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_recursiveLookupCache;
        
        /// <summary>
        /// Return a list of all resources in this folder and all sub-folders.
        /// The result of this method is cached, so subsequent calls will have very low performance cost.
        /// </summary>
        /// <returns>A list of resource objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
            if ((@__ts_internal_recursiveLookupCache != null)) {
                return @__ts_internal_recursiveLookupCache;
            }
            global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
            tmp.AddRange(GetContents());
            @__ts_internal_recursiveLookupCache = tmp;
            return @__ts_internal_recursiveLookupCache;
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder.
        /// </summary>
        public static void UnloadAll() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder and subfolders.
        /// </summary>
        private void UnloadAllRecursive() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
        }
    }
    
    public sealed class Materials {
        
        private Materials() {
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Material> FacePicker {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Material>)(@__ts_internal_resources[0]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Material> EdgePicker {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Material>)(@__ts_internal_resources[1]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Material> InvisibleFace {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Material>)(@__ts_internal_resources[2]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Material> ProBuilderDefault {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Material>)(@__ts_internal_resources[3]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Material> UnlitVertexColor {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Material>)(@__ts_internal_resources[4]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Material> VertexPicker {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Material>)(@__ts_internal_resources[5]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Material> NoDraw {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Material>)(@__ts_internal_resources[6]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Material> Trigger {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Material>)(@__ts_internal_resources[7]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Material> Collider {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Material>)(@__ts_internal_resources[8]));
            }
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                    new global::TypeSafe.Resource<global::UnityEngine.Material>("FacePicker", "Materials/FacePicker"),
                    new global::TypeSafe.Resource<global::UnityEngine.Material>("EdgePicker", "Materials/EdgePicker"),
                    new global::TypeSafe.Resource<global::UnityEngine.Material>("InvisibleFace", "Materials/InvisibleFace"),
                    new global::TypeSafe.Resource<global::UnityEngine.Material>("ProBuilderDefault", "Materials/ProBuilderDefault"),
                    new global::TypeSafe.Resource<global::UnityEngine.Material>("UnlitVertexColor", "Materials/UnlitVertexColor"),
                    new global::TypeSafe.Resource<global::UnityEngine.Material>("VertexPicker", "Materials/VertexPicker"),
                    new global::TypeSafe.Resource<global::UnityEngine.Material>("NoDraw", "Materials/NoDraw"),
                    new global::TypeSafe.Resource<global::UnityEngine.Material>("Trigger", "Materials/Trigger"),
                    new global::TypeSafe.Resource<global::UnityEngine.Material>("Collider", "Materials/Collider")});
        
        /// <summary>
        /// Return a list of all resources in this folder.
        /// This method has a very low performance cost, no need to cache the result.
        /// </summary>
        /// <returns>A list of resource objects in this folder.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
            return @__ts_internal_resources;
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_recursiveLookupCache;
        
        /// <summary>
        /// Return a list of all resources in this folder and all sub-folders.
        /// The result of this method is cached, so subsequent calls will have very low performance cost.
        /// </summary>
        /// <returns>A list of resource objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
            if ((@__ts_internal_recursiveLookupCache != null)) {
                return @__ts_internal_recursiveLookupCache;
            }
            global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
            tmp.AddRange(GetContents());
            @__ts_internal_recursiveLookupCache = tmp;
            return @__ts_internal_recursiveLookupCache;
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder.
        /// </summary>
        public static void UnloadAll() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder and subfolders.
        /// </summary>
        private void UnloadAllRecursive() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
        }
    }
    
    public sealed class Animator {
        
        private Animator() {
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> VTP_keyframe_selected {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[0]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> VTP_scroller {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[1]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> play {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[2]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> to_end {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[3]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> VTP_keyframe_unselected {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[4]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> background {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[5]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> to_start {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[6]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Texture2D> VTP_slider_red {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Texture2D>)(@__ts_internal_resources[7]));
            }
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("VTP_keyframe_selected", "Animator/VTP_keyframe_selected"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("VTP_scroller", "Animator/VTP_scroller"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("play", "Animator/play"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("to_end", "Animator/to_end"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("VTP_keyframe_unselected", "Animator/VTP_keyframe_unselected"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("background", "Animator/background"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("to_start", "Animator/to_start"),
                    new global::TypeSafe.Resource<global::UnityEngine.Texture2D>("VTP_slider_red", "Animator/VTP_slider_red")});
        
        /// <summary>
        /// Return a list of all resources in this folder.
        /// This method has a very low performance cost, no need to cache the result.
        /// </summary>
        /// <returns>A list of resource objects in this folder.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
            return @__ts_internal_resources;
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_recursiveLookupCache;
        
        /// <summary>
        /// Return a list of all resources in this folder and all sub-folders.
        /// The result of this method is cached, so subsequent calls will have very low performance cost.
        /// </summary>
        /// <returns>A list of resource objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
            if ((@__ts_internal_recursiveLookupCache != null)) {
                return @__ts_internal_recursiveLookupCache;
            }
            global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
            tmp.AddRange(GetContents());
            @__ts_internal_recursiveLookupCache = tmp;
            return @__ts_internal_recursiveLookupCache;
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder.
        /// </summary>
        public static void UnloadAll() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder and subfolders.
        /// </summary>
        private void UnloadAllRecursive() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
        }
    }
    
    /// <summary>
    /// Return a list of all resources in this folder.
    /// This method has a very low performance cost, no need to cache the result.
    /// </summary>
    /// <returns>A list of resource objects in this folder.</returns>
    public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
        return @__ts_internal_resources;
    }
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_recursiveLookupCache;
    
    /// <summary>
    /// Return a list of all resources in this folder and all sub-folders.
    /// The result of this method is cached, so subsequent calls will have very low performance cost.
    /// </summary>
    /// <returns>A list of resource objects in this folder and sub-folders.</returns>
    public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
        if ((@__ts_internal_recursiveLookupCache != null)) {
            return @__ts_internal_recursiveLookupCache;
        }
        global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
        tmp.AddRange(GetContents());
        tmp.AddRange(Textures.GetContentsRecursive());
        tmp.AddRange(Materials.GetContentsRecursive());
        tmp.AddRange(Animator.GetContentsRecursive());
        @__ts_internal_recursiveLookupCache = tmp;
        return @__ts_internal_recursiveLookupCache;
    }
    
    /// <summary>
    /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
    /// This method does not cache the result, so you should cache the result yourself if you will use it often.
    /// </summary>
    /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
    public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
        where TResource : global::UnityEngine.Object {
        return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
    }
    
    /// <summary>
    /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
    /// This method does not cache the result, so you should cache the result yourself if you will use it often.
    /// </summary>
    /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
    public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
        where TResource : global::UnityEngine.Object {
        return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
    }
    
    /// <summary>
    /// Call Unload() on every loaded resource in this folder.
    /// </summary>
    public static void UnloadAll() {
        global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
    }
    
    /// <summary>
    /// Call Unload() on every loaded resource in this folder and subfolders.
    /// </summary>
    private void UnloadAllRecursive() {
        global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
    }
}
