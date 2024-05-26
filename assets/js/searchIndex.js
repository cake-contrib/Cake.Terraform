
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"TerraformPlanSettings",
            content:"TerraformPlanSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Plan/TerraformPlanSettings',
            title:"TerraformPlanSettings",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"TerraformEnvSettings EnvCommandType",
            content:"TerraformEnvSettings EnvCommandType",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform/EnvCommandType',
            title:"TerraformEnvSettings.EnvCommandType",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"TerraformEnvDeleteSettings",
            content:"TerraformEnvDeleteSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.EnvDelete/TerraformEnvDeleteSettings',
            title:"TerraformEnvDeleteSettings",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"TerraformEnvSettings",
            content:"TerraformEnvSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform/TerraformEnvSettings',
            title:"TerraformEnvSettings",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"TerraformDestroyRunner",
            content:"TerraformDestroyRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Destroy/TerraformDestroyRunner',
            title:"TerraformDestroyRunner",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"TerraformPlanRunner",
            content:"TerraformPlanRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Plan/TerraformPlanRunner',
            title:"TerraformPlanRunner",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"TerraformOutputRunner",
            content:"TerraformOutputRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Output/TerraformOutputRunner',
            title:"TerraformOutputRunner",
            description:""
        }
    );
    a(
        {
            id:7,
            title:"TerraformEnvListRunner",
            content:"TerraformEnvListRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.EnvList/TerraformEnvListRunner',
            title:"TerraformEnvListRunner",
            description:""
        }
    );
    a(
        {
            id:8,
            title:"TerraformInitSettings",
            content:"TerraformInitSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Init/TerraformInitSettings',
            title:"TerraformInitSettings",
            description:""
        }
    );
    a(
        {
            id:9,
            title:"TerraformEnvNewRunner",
            content:"TerraformEnvNewRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.EnvNew/TerraformEnvNewRunner',
            title:"TerraformEnvNewRunner",
            description:""
        }
    );
    a(
        {
            id:10,
            title:"TerraformApplySettings",
            content:"TerraformApplySettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Apply/TerraformApplySettings',
            title:"TerraformApplySettings",
            description:""
        }
    );
    a(
        {
            id:11,
            title:"TerraformValidateSettings",
            content:"TerraformValidateSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Validate/TerraformValidateSettings',
            title:"TerraformValidateSettings",
            description:""
        }
    );
    a(
        {
            id:12,
            title:"TerraformShowSettings",
            content:"TerraformShowSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Show/TerraformShowSettings',
            title:"TerraformShowSettings",
            description:""
        }
    );
    a(
        {
            id:13,
            title:"TerraformSettings",
            content:"TerraformSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform/TerraformSettings',
            title:"TerraformSettings",
            description:""
        }
    );
    a(
        {
            id:14,
            title:"TerraformValidateRunner",
            content:"TerraformValidateRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Validate/TerraformValidateRunner',
            title:"TerraformValidateRunner",
            description:""
        }
    );
    a(
        {
            id:15,
            title:"TerraformAliases",
            content:"TerraformAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform/TerraformAliases',
            title:"TerraformAliases",
            description:""
        }
    );
    a(
        {
            id:16,
            title:"TerraformOutputSettings",
            content:"TerraformOutputSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Output/TerraformOutputSettings',
            title:"TerraformOutputSettings",
            description:""
        }
    );
    a(
        {
            id:17,
            title:"TerraformEnvNewSettings",
            content:"TerraformEnvNewSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.EnvNew/TerraformEnvNewSettings',
            title:"TerraformEnvNewSettings",
            description:""
        }
    );
    a(
        {
            id:18,
            title:"OutputFormat",
            content:"OutputFormat",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Show/OutputFormat',
            title:"OutputFormat",
            description:""
        }
    );
    a(
        {
            id:19,
            title:"TerraformRefreshSettings",
            content:"TerraformRefreshSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Refresh/TerraformRefreshSettings',
            title:"TerraformRefreshSettings",
            description:""
        }
    );
    a(
        {
            id:20,
            title:"TerraformDestroySettings",
            content:"TerraformDestroySettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Destroy/TerraformDestroySettings',
            title:"TerraformDestroySettings",
            description:""
        }
    );
    a(
        {
            id:21,
            title:"TerraformRefreshRunner",
            content:"TerraformRefreshRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Refresh/TerraformRefreshRunner',
            title:"TerraformRefreshRunner",
            description:""
        }
    );
    a(
        {
            id:22,
            title:"TerraformEnvDeleteRunner",
            content:"TerraformEnvDeleteRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.EnvDelete/TerraformEnvDeleteRunner',
            title:"TerraformEnvDeleteRunner",
            description:""
        }
    );
    a(
        {
            id:23,
            title:"TerraformRunner",
            content:"TerraformRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform/TerraformRunner_1',
            title:"TerraformRunner<TTerraformSettings>",
            description:""
        }
    );
    a(
        {
            id:24,
            title:"TerraformEnvSelectSettings",
            content:"TerraformEnvSelectSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.EnvSelect/TerraformEnvSelectSettings',
            title:"TerraformEnvSelectSettings",
            description:""
        }
    );
    a(
        {
            id:25,
            title:"TerraformApplyRunner",
            content:"TerraformApplyRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Apply/TerraformApplyRunner',
            title:"TerraformApplyRunner",
            description:""
        }
    );
    a(
        {
            id:26,
            title:"TerraformEnvSelectRunner",
            content:"TerraformEnvSelectRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.EnvSelect/TerraformEnvSelectRunner',
            title:"TerraformEnvSelectRunner",
            description:""
        }
    );
    a(
        {
            id:27,
            title:"TerraformInitRunner",
            content:"TerraformInitRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Init/TerraformInitRunner',
            title:"TerraformInitRunner",
            description:""
        }
    );
    a(
        {
            id:28,
            title:"TerraformShowRunner",
            content:"TerraformShowRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.Show/TerraformShowRunner',
            title:"TerraformShowRunner",
            description:""
        }
    );
    a(
        {
            id:29,
            title:"TerraformEnvListSettings",
            content:"TerraformEnvListSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Terraform/api/Cake.Terraform.EnvList/TerraformEnvListSettings',
            title:"TerraformEnvListSettings",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
