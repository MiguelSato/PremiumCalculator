function calculateAge(birthdate){

    var today = new Date();

    var currentYear = today.getFullYear();
    
    var birthYear = birthdate.getFullYear();

    var age = currentYear - birthYear - 1;

    //we change both years to the same year
    //we usee 2020 because it was a leap year, so every date should be a valid one

    birthdate.setFullYear(2020);
    today.setFullYear(2020);

    if(birthdate <= today) age ++;

    return age;

}