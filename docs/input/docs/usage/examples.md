# Build Script

In order to make use of the Cake.Terraform Addin, you will need to first use the `#addin` preprocessor to install Cake.Terraform, but once that is done, you can directly use the available aliases.

In addition, the `terraform` tool will need to be installed and available on the machine on which the script is running. Alternatively, you can provide a `ToolPath` to where it can be located.

## TerraformInit
```csharp
#addin Cake.Terraform

Task("Init")
    .Does(() =>
{
    TerraformInit();
});
```

or, with specific settings:

```csharp
#addin Cake.Terraform

Task("Plan")
    .Does(() =>
{
    var settings = new TerraformInitSettings {
        WorkingDirectory = "./terraform"
    };
    TerraformInit(settings);
});
```

## TerraformPlan

```csharp
#addin Cake.Terraform

Task("Plan")
    .Does(() =>
{
    TerraformPlan();
});
```

or, with specific settings:

```csharp
#addin Cake.Terraform

Task("Plan")
    .Does(() =>
{
    var settings = new TerraformPlanSettings {
        WorkingDirectory = "./terraform",
        OutFile = "./output/terraform.plan"
    };
    TerraformPlan(settings);
});
```

## TerraformShow

```csharp
#addin Cake.Terraform

Task("Show")
    .Does(() =>
{
    TerraformShow();
});
```

or, with specific settings:

```csharp
#addin Cake.Terraform

Task("Plan")
    .Does(() =>
{
    var settings = new TerraformShowSettings {
        PlanFile = "./output/terraform.plan",
        OutFile = "./output/terraform.txt"
    };
    TerraformShow(settings);
});
```

## TerraformApply

```csharp
#addin Cake.Terraform

Task("Apply")
    .Does(() =>
{
    TerraformApply();
});
```

or, with specific settings:

```csharp
#addin Cake.Terraform

Task("Apply")
    .Does(() =>
{
    var settings = new TerraformApplySettings {
        Plan = "./output/terraform.plan"
    };
    TerraformApply(settings);
});

