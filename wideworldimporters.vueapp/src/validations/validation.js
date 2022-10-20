import { extend } from "vee-validate";
import { required } from "vee-validate/dist/rules"

/*extend('required', email =>{
    if(email != ''){
        return true;
    }
    return 'Debe llenar el campo {_field_}';
});*/

extend('required', required);