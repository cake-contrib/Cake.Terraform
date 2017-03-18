using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Terraform
{
    [CakeAliasCategory("Terraform")]
    public static class TerraformAliases
    {
        [CakeMethodAlias]
        public static void TerraformInit(this ICakeContext context, TerraformInitSettings settings)
        {
            var runner = new TerraformBuildRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, new TerraformToolResolver(context.FileSystem, context.Environment));
            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static bool TerraformPlan(this ICakeContext context, TerraformPlanSettings settings)
        {
            var runner = new TerraformBuildRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, new TerraformToolResolver(context.FileSystem, context.Environment));
            runner.Run(settings);
            return runner.HasChanges;
        }

        [CakeMethodAlias]
        public static void TerraformApply(this ICakeContext context)
        {

        }
    }
}