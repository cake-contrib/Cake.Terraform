
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"TerraformShowRunner",
        content:"TerraformShowRunner",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"TerraformInitRunner",
        content:"TerraformInitRunner",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"TerraformPlanSettings",
        content:"TerraformPlanSettings",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"TerraformShowSettings",
        content:"TerraformShowSettings",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"TerraformApplyRunner",
        content:"TerraformApplyRunner",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"TerraformPlanRunner",
        content:"TerraformPlanRunner",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"TerraformApplySettings",
        content:"TerraformApplySettings",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"TerraformAliases",
        content:"TerraformAliases",
        description:'',
        tags:''
    });

    a({
        id:8,
        title:"TerraformInitSettings",
        content:"TerraformInitSettings",
        description:'',
        tags:''
    });

    a({
        id:9,
        title:"TerraformRunner",
        content:"TerraformRunner",
        description:'',
        tags:''
    });

    a({
        id:10,
        title:"TerraformSettings",
        content:"TerraformSettings",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.Terraform/Cake.Terraform/api/Cake.Terraform/TerraformShowRunner',
        title:"TerraformShowRunner",
        description:""
    });

    y({
        url:'/Cake.Terraform/Cake.Terraform/api/Cake.Terraform/TerraformInitRunner',
        title:"TerraformInitRunner",
        description:""
    });

    y({
        url:'/Cake.Terraform/Cake.Terraform/api/Cake.Terraform/TerraformPlanSettings',
        title:"TerraformPlanSettings",
        description:""
    });

    y({
        url:'/Cake.Terraform/Cake.Terraform/api/Cake.Terraform/TerraformShowSettings',
        title:"TerraformShowSettings",
        description:""
    });

    y({
        url:'/Cake.Terraform/Cake.Terraform/api/Cake.Terraform/TerraformApplyRunner',
        title:"TerraformApplyRunner",
        description:""
    });

    y({
        url:'/Cake.Terraform/Cake.Terraform/api/Cake.Terraform/TerraformPlanRunner',
        title:"TerraformPlanRunner",
        description:""
    });

    y({
        url:'/Cake.Terraform/Cake.Terraform/api/Cake.Terraform/TerraformApplySettings',
        title:"TerraformApplySettings",
        description:""
    });

    y({
        url:'/Cake.Terraform/Cake.Terraform/api/Cake.Terraform/TerraformAliases',
        title:"TerraformAliases",
        description:""
    });

    y({
        url:'/Cake.Terraform/Cake.Terraform/api/Cake.Terraform/TerraformInitSettings',
        title:"TerraformInitSettings",
        description:""
    });

    y({
        url:'/Cake.Terraform/Cake.Terraform/api/Cake.Terraform/TerraformRunner_1',
        title:"TerraformRunner<TTerraformSettings>",
        description:""
    });

    y({
        url:'/Cake.Terraform/Cake.Terraform/api/Cake.Terraform/TerraformSettings',
        title:"TerraformSettings",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
