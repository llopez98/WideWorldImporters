<template>
    <v-container grid-list-xs>
        <form  @keyup.enter="submit">
            <v-text-field v-model="registration.email" label="E-mail" required :rules="rules.email"></v-text-field>
            <v-text-field v-model="registration.password" label="Password" type="password" required :rules="rules.password"></v-text-field>
            <v-text-field v-model="registration.confirmPassword" label="Confirm Password" type="password" required>
            </v-text-field>
            <v-btn class="mr-4" @click="submit">
                submit
            </v-btn>
        </form>
        <br>
        <v-alert dense text type="success" v-model="alert">
            Registration Successfull!
        </v-alert>
        <v-alert dense outlined type="error" v-model="danger" transition="scale-transition">
            Registration Failed!
        </v-alert>
        <v-alert dense outlined type="error" v-model="danger2" transition="scale-transition">
            All fields are required!
        </v-alert>
    </v-container>

</template>

<script>
import * as loginHandler from '../handlers/login'

export default {
    name: 'Register',
    data: () => ({
        drawer: false,
        group: null,
        alert: false,
        danger: false,
        danger2: false,
        registration: {
            email: "",
            password: "",
            confirmPassword: ""
        },
        rules: {
            email: [val => (val || '').length > 0 || 'Email is required'],
            password: [val => (val || '').length > 0  || 'Password is required']
        }
    }),
    methods: {
        submit(e) {
            if (this.registration.email == '' || this.registration.password == '' || this.registration.confirmPassword == '') {
                this.danger2 = true;
            } else {
                loginHandler.RegisterUser(this.registration).then(
                    (resp) => {
                        if (resp.status == 201) {
                            this.danger = false;
                            this.alert = true;
                            setTimeout(() => {
                                window.location.href = "#/login";
                            }, 5000);
                        } else {
                            this.danger = true;
                        }
                    }
                ).catch((error) => {
                    console.log(error);
                });
            }
        }
    }
}
</script>