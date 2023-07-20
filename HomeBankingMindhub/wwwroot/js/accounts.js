var app = new Vue({
    el:"#app",
    data:{
        clientInfo: {},
        error: null,
        accounts: [],
        loans: [],
    },
    methods:{
        getData: function(){
            axios.get("/api/clients/1")
            .then(function (response) {
                //get client ifo
                console.log(response.data)
                app.accounts = response.data.accounts.$values
                app.clientInfo = response.data;
                app.loans = response.data.loans.$values
            })
            .catch(function (error) {
                // handle error
                app.error = error;
            })
        },
        formatDate: function(date){
            return new Date(date).toLocaleDateString('en-gb');
        }
    },
    created(){
        this.getData();
    },
    mounted: function(){
      
    }
})