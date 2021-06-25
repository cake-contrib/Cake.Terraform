using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Terraform.Apply;
using Cake.Terraform.Destroy;
using Cake.Terraform.EnvDelete;
using Cake.Terraform.EnvList;
using Cake.Terraform.EnvNew;
using Cake.Terraform.EnvSelect;
using Cake.Terraform.Init;
using Cake.Terraform.Output;
using Cake.Terraform.Plan;
using Cake.Terraform.Refresh;
using Cake.Terraform.Show;

namespace Cake.Terraform
{
    [CakeAliasCategory("Terraform")]
    public static class TerraformAliases
    {
        [CakeMethodAlias]
        public static void TerraformInit(this ICakeContext context)
        {
            TerraformInit(context, new TerraformInitSettings());
        }

        [CakeMethodAlias]
        public static void TerraformInit(this ICakeContext context, TerraformInitSettings settings)
        {
            var runner = new TerraformInitRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static bool TerraformPlan(this ICakeContext context)
        {
            return TerraformPlan(context, new TerraformPlanSettings());
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
            TerraformApply(context, new TerraformApplySettings());
        }

        [CakeMethodAlias]
        public static void TerraformApply(this ICakeContext context, TerraformApplySettings settings)
        {
            var runner = new TerraformApplyRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static void TerraformShow(this ICakeContext context)
        {
            TerraformShow(context, new TerraformShowSettings());
        }

        [CakeMethodAlias]
        public static void TerraformShow(this ICakeContext context, TerraformShowSettings settings)
        {
            var runner = new TerraformShowRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static void TerraformDestroy(this ICakeContext context)
        {
            TerraformDestroy(context, new TerraformDestroySettings());
        }

        [CakeMethodAlias]
        public static void TerraformDestroy(this ICakeContext context, TerraformDestroySettings settings)
        {
            var runner = new TerraformDestroyRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static void TerraformEnvDelete(this ICakeContext context)
        {
            TerraformEnvDelete(context, new TerraformEnvDeleteSettings());
        }

        [CakeMethodAlias]
        public static void TerraformEnvDelete(this ICakeContext context, TerraformEnvDeleteSettings settings)
        {
            var runner = new TerraformEnvDeleteRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static void TerraformEnvList(this ICakeContext context)
        {
            TerraformEnvList(context, new TerraformEnvListSettings());
        }

        [CakeMethodAlias]
        public static List<string> TerraformEnvList(this ICakeContext context, TerraformEnvListSettings settings)
        {
            var runner = new TerraformEnvListRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.Run(settings);
        }

        [CakeMethodAlias]
        public static void TerraformEnvNew(this ICakeContext context, string environment)
        {
            TerraformEnvNew(context, new TerraformEnvNewSettings { Environment = environment });
        }

        [CakeMethodAlias]
        public static void TerraformEnvNew(this ICakeContext context, TerraformEnvNewSettings settings)
        {
            var runner = new TerraformEnvNewRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static void TerraformEnvSelect(this ICakeContext context, string environment)
        {
            TerraformEnvSelect(context, new TerraformEnvSelectSettings { Environment = environment });
        }

        [CakeMethodAlias]
        public static void TerraformEnvSelect(this ICakeContext context, TerraformEnvSelectSettings settings)
        {
            var runner = new TerraformEnvSelectRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static void TerraformRefresh(this ICakeContext context)
        {
            TerraformRefresh(context, new TerraformRefreshSettings());
        }

        [CakeMethodAlias]
        public static void TerraformRefresh(this ICakeContext context, TerraformRefreshSettings settings)
        {
            var runner = new TerraformRefreshRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static string TerraformOutput(this ICakeContext context, TerraformOutputSettings settings)
        {
            var runner = new TerraformOutputRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.Run(settings);
        }
    }
}
