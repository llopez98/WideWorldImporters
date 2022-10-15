<template>
    <v-container grid-list-xs>
        <form>
            <v-text-field v-model="login.email" label="E-mail" required :rules="rules.email"></v-text-field>
            <v-text-field v-model="login.password" label="Password" type="password" required :rules="rules.password">
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
import * as loginHandler from '../handlers/login'

export default {
    name: 'LoginComponent',
    data: () => ({
        drawer: false,
        group: null,
        alert: false,
        danger: false,
        danger2: false,
        login: {
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
            if (this.login.email == '' || this.login.password == '') {
                this.danger2 = true;
            } else {
                loginHandler.SendLoginData(this.login).then(
                    (resp) => {
                        this.danger == false;
                        this.danger2 == false;
                        if (resp.status == 200) {
                            this.alert == true;
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