
$(document).ready(function(){
    
    //set onchange method for birthdate

    $('#birthdate').change(function(){
        
        var inputDate = new Date(this.value);

        var  age = calculateAge(inputDate);

        $('#age').val(age);

        console.log(age);

    });
});


$(document).ready(function(){
    
    $.getJSON('usa_states.json', function(data){
        var states = data.usa_states.items;

        console.log(data);

        $.each( data.usa_states, function(index, item){
            var name = item.name;
            var code = item.code;

            $('#states').append($('<option>').val(code).text(name));
        });
        
    });


});


$(document).ready(function(){

    $('#premium_button').click(function(){

        var form = $('#birthdate')[0];

        if(!form.checkValidity()){
            form.reportValidity();
            return;
        }

        //
        var url = "https://localhost:44349//Premium.asmx";

        var date = $('#birthdate').val();

        var state = $('#states').val();

        var age = $('#age').val();


        console.log(date + " - " + state + " - " + age);

        $.ajax({

            type:"POST",
            url: url + "/CalculatePremium",
            data: `{birthdate:'${date}', state:'${state}', age:'${age}'}`,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessCall,
            error: OnErrorCall

        });


        function OnSuccessCall(response) {
            
            var json = JSON.parse(response.d);
            console.log("premium: "+json.premium);

            $('#premium_text').val(json.premium);

            $('#period_select').prop("disabled", false);
            $('#period_select').css("background-color", "white");
        }
    
    
        function OnErrorCall(response) {
            alert("Error connecting to 'CalculatePremium' service.");
        }


    });

});


$(document).ready(function(){

    $('#period_select').change(function(){
        
        var selectedValue = $('#period_select').val();

        var premium = $('#premium_text').val();

        var monthlyValue = 0;

        switch(selectedValue){

            case "monthly" : monthlyValue = premium; break;
            case "quarterly": monthlyValue = premium/3; break;
            case "semi-annual": monthlyValue = premium/6; break;
            case "annual" : monthlyValue = premium/12; break;
        }

        $('#annual').val(Number(monthlyValue*12).toFixed(2));

        $('#monthly').val(Number(monthlyValue).toFixed(2));
    });

});