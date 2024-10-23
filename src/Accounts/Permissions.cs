﻿namespace SwarmUI.Accounts;

/// <summary>General handler for the available permissions list.</summary>
public static class Permissions
{
    /// <summary>Map of all known registered permissions from their IDs.</summary>
    public static ConcurrentDictionary<string, PermInfo> Registered = [];

    /// <summary>Registers the permission info to the global list, and returns a copy of it.</summary>
    public static PermInfo Register(PermInfo perm)
    {
        if (!Registered.TryAdd(perm.ID, perm))
        {
            throw new InvalidOperationException($"Permission key '{perm.ID}' is already registered.");
        }
        return perm;
    }

    public static PermInfoGroup GroupSpecial = new("Admin", "Special permissions that don't make sense to give out.");

    public static PermInfo Admin = Register(new("*", "Full Control", "Allows full control over everything.\nA magic wildcard to allow all permissions.\nOnly the owner should have this.", PermissionDefault.NOBODY, GroupSpecial));
    public static PermInfo LocalImageFolder = Register(new("local_image_folder", "Local Image Folder", "Allows access to the button that opens a local image folder. Only functions if you're on the same PC as the server.", PermissionDefault.NOBODY, GroupSpecial));
    public static PermInfo Install = Register(new("install", "Install", "Allows access to initial installer system. If you can read this text, you don't need to give this permission to anyone.", PermissionDefault.NOBODY, GroupSpecial));
    public static PermInfo ServerDebugMessage = Register(new("server_debug_message", "Server Debug Message", "Allows the user to send server debug messages (this is for internal debugging, not anything normal).", PermissionDefault.NOBODY, GroupSpecial));

    public static PermInfoGroup GroupAdmin = new("Admin", "Permissions for server administration access.");

    public static PermInfo ConfigureRoles = Register(new("configure_roles", "Configure Roles", "Allows access to role configuration.\nThis is basically total control, as you can give yourself more permissions with this.", PermissionDefault.NOBODY, GroupAdmin));
    public static PermInfo Shutdown = Register(new("shutdown", "Shutdown Server", "Allows the user to fully shut down the server.", PermissionDefault.NOBODY, GroupAdmin));
    public static PermInfo Restart = Register(new("restart", "Restart Server", "Allows the user to fully restart the server.", PermissionDefault.ADMINS, GroupAdmin));
    public static PermInfo ReadServerSettings = Register(new("read_server_settings", "Read Server Settings", "Allows the user to read (but not necessarily edit) server settings.", PermissionDefault.ADMINS, GroupAdmin));
    public static PermInfo EditServerSettings = Register(new("edit_server_settings", "Edit Server Settings", "Allows the user to edit server settings. Note that this is basically god power, a user can disable auth requirements here and then give themselves more permissions.", PermissionDefault.ADMINS, GroupAdmin));
    public static PermInfo ViewLogs = Register(new("view_logs", "View Server Logs", "Allows the user to view server logs.", PermissionDefault.ADMINS, GroupAdmin));
    public static PermInfo ReadServerInfoPanels = Register(new("read_server_info_panels", "Read Server Info Panels", "Allows the user to read server info panels (resource usage, connected users, ...).", PermissionDefault.ADMINS, GroupAdmin));
    public static PermInfo AdminDebug = Register(new("admin_debug", "Admin Debug APIs", "Allows the user to access administrative debug APIs.", PermissionDefault.ADMINS, GroupAdmin));
    public static PermInfo ManageExtensions = Register(new("manage_extensions", "Manage Extensions", "Allows the user to manage (install, update, remove) extensions.", PermissionDefault.ADMINS, GroupAdmin));
    public static PermInfo ViewOthersOutputs = Register(new("view_others_outputs", "View Others Outputs", "Allows the user to view the outputs of other users.", PermissionDefault.ADMINS, GroupAdmin));
    public static PermInfo ViewServerTab = Register(new("view_server_tab", "View Server Tab", "Allows the user to view the server tab.", PermissionDefault.POWERUSERS, GroupAdmin));

    public static PermInfoGroup GroupBackendsAdmin = new("Backends Admin", "Permissions for managing backends.");

    public static PermInfo ViewBackendsList = Register(new("view_backends_list", "View Backends List", "Allows the user to view the list of available backends.", PermissionDefault.POWERUSERS, GroupBackendsAdmin));
    public static PermInfo AddRemoveBackends = Register(new("add_remove_backends", "Add/Remove Backends", "Allows the user to add or remove backends.", PermissionDefault.ADMINS, GroupBackendsAdmin));
    public static PermInfo EditBackends = Register(new("edit_backends", "Edit Backends", "Allows the user to edit backends.", PermissionDefault.ADMINS, GroupBackendsAdmin));
    public static PermInfo RestartBackends = Register(new("restart_backends", "Restart Backends", "Allows the user to restart backends.", PermissionDefault.POWERUSERS, GroupBackendsAdmin));
    public static PermInfo ToggleBackends = Register(new("toggle_backends", "Toggle Backends", "Allows the user to toggle backends on or off.", PermissionDefault.ADMINS, GroupBackendsAdmin));

    public static PermInfoGroup GroupControl = new("Control", "Control over common server functionality.");

    public static PermInfo ControlModelRefresh = Register(new("control_model_refresh", "Control Model Refresh", "Allows this user to refresh model lists.", PermissionDefault.POWERUSERS, GroupControl));
    public static PermInfo InstallFeatures = Register(new("install_features", "Install New Features", "Allows this user to install new features (from the list of safe pre-defined features).", PermissionDefault.POWERUSERS, GroupControl));
    public static PermInfo CreateTRT = Register(new("create_tensorrt", "Create TensorRT Models", "Allows this user to create new TensorRT models.", PermissionDefault.POWERUSERS, GroupControl));
    public static PermInfo ExtractLoRAs = Register(new("extra_loras", "Extract LoRAs", "Allows this user to extra LoRAs.", PermissionDefault.POWERUSERS, GroupControl));
    public static PermInfo ControlMemClean = Register(new("control_mem_clean", "Control Memory Cleaning", "Allows this user to control memory cleaning (eg cleanup VRAM or system RAM usage).", PermissionDefault.POWERUSERS, GroupControl));
    public static PermInfo LoadModelsNow = Register(new("load_models_now", "Load Models Now", "Allows this user to load models immediately across all backends.", PermissionDefault.POWERUSERS, GroupControl));
    public static PermInfo EditWildcards = Register(new("edit_wildcards", "Edit Wildcards", "Allows this user to create, edit, or delete wildcards.", PermissionDefault.POWERUSERS, GroupControl));
    public static PermInfo EditModelMetadata = Register(new("edit_model_metadata", "Edit Model Metadata", "Allows this user to edit model metadata.", PermissionDefault.POWERUSERS, GroupControl));
    public static PermInfo DownloadModels = Register(new("download_models", "Download Models", "Allows this user to download models.", PermissionDefault.POWERUSERS, GroupControl));
    public static PermInfo ResetMetadata = Register(new("reset_metadata", "Reset Metadata", "Allows this user to use the special utility to reset all metadata.", PermissionDefault.POWERUSERS, GroupControl));
    public static PermInfo Pickle2Safetensors = Register(new("pickle2safetensors", "Pickle2SafeTensors", "Allows this user to use the special utility to convert pickle models to safetensors.", PermissionDefault.POWERUSERS, GroupControl));

    public static PermInfoGroup GroupParams = new("Parameters", "Permissions for basic parameter access.");

    public static PermInfo ModelParams = Register(new("model_params", "Model Params", "Allows the user to select models. This is basically required to do anything.", PermissionDefault.USER, GroupParams));
    public static PermInfo ParamBackendType = Register(new("param_backend_type", "Backend Type Parameter", "Allows the user to select a specific backend type.", PermissionDefault.POWERUSERS, GroupParams));
    public static PermInfo ParamBackendID = Register(new("param_backend_id", "Backend ID Parameter", "Allows the user to select a specific backend ID.", PermissionDefault.POWERUSERS, GroupParams));
    public static PermInfo ParamVideo = Register(new("param_video", "Video Params", "Allows the user to generate videos.", PermissionDefault.USER, GroupParams));
    public static PermInfo ParamControlNet = Register(new("param_controlnet", "ControlNet Params", "Allows the user to generate with controlnets.", PermissionDefault.USER, GroupParams));

    public static PermInfoGroup GroupUser = new("User", "Permissions related to basic user access.");

    public static PermInfo BasicImageGeneration = Register(new("basic_image_generation", "Basic Image Generation", "Allows this user to generate images.", PermissionDefault.USER, GroupUser));
    public static PermInfo ViewImageHistory = Register(new("view_image_history", "View Image History", "Allows this user to view their own image history.", PermissionDefault.USER, GroupUser));
    public static PermInfo UserDeleteImage = Register(new("user_delete_image", "User Delete Image", "Allows this user to delete images they generated.", PermissionDefault.USER, GroupUser));
    public static PermInfo UserStarImages = Register(new("user_star_images", "User Star Images", "Allows this user to star or unstar images they generated.", PermissionDefault.USER, GroupUser));
    public static PermInfo FundamentalModelAccess = Register(new("fundamental_model_access", "Fundamental Model Access", "Allows this user basic access to model list functionality.", PermissionDefault.GUEST, GroupUser));
    public static PermInfo UseTokenizer = Register(new("use_tokenizer", "Use Tokenizer", "Allows this user to use the tokenizer (including the Utility tab, and the prompt token counter.", PermissionDefault.GUEST, GroupUser));
    public static PermInfo FundamentalGenerateTabAccess = Register(new("fundamental_generate_tab_access", "Fundamental Generate Tab Access", "Allows this user to access the generate tab. This is basically required to even open the UI.", PermissionDefault.GUEST, GroupUser));
    public static PermInfo ReadUserSettings = Register(new("read_user_settings", "Read User Settings", "Allows this user to view their own settings.", PermissionDefault.GUEST, GroupUser));
    public static PermInfo EditUserSettings = Register(new("edit_user_settings", "Edit User Settings", "Allows this user to edit their own settings.", PermissionDefault.USER, GroupUser));
    public static PermInfo EditParams = Register(new("edit_params", "Edit Params", "Allows this user to edit params (in a way that only affects themself, not other users).", PermissionDefault.USER, GroupUser));
    public static PermInfo ManagePresets = Register(new("manage_presets", "Manage Presets", "Allows this user to manage (add, edit, delete) their own presets.", PermissionDefault.USER, GroupUser));

    public static PermInfoGroup GroupExtensionTabs = new("Extension Tabs", "Permissions related to extension tabs.");
}

/// <summary>Enumeration of default modes for permissions.</summary>
public enum PermissionDefault
{
    /// <summary>Nobody should have this by default (except the server owner).</summary>
    NOBODY = 0,
    /// <summary>Only admins should have this by default, not regular users.</summary>
    ADMINS = 1,
    /// <summary>Only advanced/trusted power users and admins should have this by default, not regular users.</summary>
    POWERUSERS = 2,
    /// <summary>Any registered user can have this by default, it's safe and only permission walled to allow the server owner to disable it.</summary>
    USER = 3,
    /// <summary>An unregistered guest user can use this (if unregistered access is enabled), it's extremely safe.</summary>
    GUEST = 4
}

/// <summary>A grouping of permission flags, purely for UI clarity.</summary>
/// <param name="DisplayName">The human-readable display name of the group.</param>
/// <param name="Description">Human-readable display text of what the group is for.</param>
public record class PermInfoGroup(string DisplayName, string Description)
{
}

/// <summary>Information about a single permission key.</summary>
/// <param name="ID">Short unique identifier of this permission key.</param>
/// <param name="DisplayName">Human-readable display name for the permission.</param>
/// <param name="Description">Simple human-readable description text of what this permission controls.</param>
/// <param name="Default">Who should have this permission by default.</param>
/// <param name="Group">What group this permission is in.</param>
public record class PermInfo(string ID, string DisplayName, string Description, PermissionDefault Default, PermInfoGroup Group)
{
}