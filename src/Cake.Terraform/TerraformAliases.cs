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
            var runner = new TerraformInitRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static bool TerraformPlan(this ICakeContext context, TerraformPlanSettings settings)
        {
            var runner = new TerraformPlanRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
            return runner.HasChanges;
        }

        [CakeMethodAlias]
        public static void TerraformApply(this ICakeContext context)
        {

        }
    }
}