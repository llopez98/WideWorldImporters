<template>
    <v-container grid-list-xs>
        <form>
            <v-text-field v-model="userAuthentication.email" label="E-mail" required :rules="rules.email"></v-text-field>
            <v-text-field v-model="userAuthentication.password" label="Password" type="password" required :rules="rules.password">
            </v-text-field>
            <v-btn class="mr-4" @click="submit">
                submit
            </v-btn>
        </form>
        <v-alert dense text type="success" v-model="alert">
            Login Successfull!
        </v-alert>
        <v-alert dense outlined type="error" v-model="danger" transition="scale-transition">
            Login Failed!
        </v-alert>
        <v-alert dense outlined type="error" v-model="danger2" transition="scale-transition">
            All fields are required!
        </v-alert>
    </v-container>

</template>

<script>
import * as loginService from '../services/auth'
//import * as intercepService from '../services/interceptor'

export default {
    name: 'LoginComponent',
    data: () => ({
        drawer: false,
        group: null,
        alert: false,
        danger: false,
        danger2: false,
        userAuthentication: {
            email: "",
            password: ""
        },
        rules: {
            email: [val => (val || '').length > 0 || 'Email is required'],
            password: [val => (val || '').length > 0 || 'Password is required']
        }
    }),
    methods: {
        submit(e) {
            if (this.userAuthentication.email == '' || this.userAuthentication.password == '') {
                this.danger2 = true;
            } else {
                loginService.SendLoginData(this.userAuthentication).then(
                    (resp) => {
                        this.danger == false;
                        this.danger2 == false;
                        if (resp) {
                            this.alert == true;
                            //intercepService.CheckExpTime();
                            setTimeout(() => {
                                window.location.href = "/";
                            }, 5000);
                        }else{
                            this.danger = true;
                        }
                    }
                ).catch((error) => console.log(error));
            }
        }
    }
}
</script>