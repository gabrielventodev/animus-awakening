// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class Animus_Awakening : ModuleRules
{
	public Animus_Awakening(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] {
			"Core",
			"CoreUObject",
			"Engine",
			"InputCore",
			"EnhancedInput",
			"AIModule",
			"NavigationSystem",
			"StateTreeModule",
			"GameplayStateTreeModule",
			"Niagara",
			"UMG",
			"Slate"
		});

		PrivateDependencyModuleNames.AddRange(new string[] { });

		PublicIncludePaths.AddRange(new string[] {
			"Animus_Awakening",
			"Animus_Awakening/Variant_Strategy",
			"Animus_Awakening/Variant_Strategy/UI",
			"Animus_Awakening/Variant_TwinStick",
			"Animus_Awakening/Variant_TwinStick/AI",
			"Animus_Awakening/Variant_TwinStick/Gameplay",
			"Animus_Awakening/Variant_TwinStick/UI"
		});

		// Uncomment if you are using Slate UI
		// PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

		// Uncomment if you are using online features
		// PrivateDependencyModuleNames.Add("OnlineSubsystem");

		// To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
	}
}
