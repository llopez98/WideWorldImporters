<template>
    <v-container grid-list-xs>
        <form>
            <v-text-field v-model="registration.email" label="E-mail" required></v-text-field>
            <v-text-field v-model="registration.password" label="Password" type="password" required></v-text-field>
            <v-text-field v-model="registration.confirmPassword" label="Confirm Password" type="password" required></v-text-field>
            <v-btn class="mr-4" @click="submit">
                submit
            </v-btn>
        </form>
    </v-container>

</template>

<script>
import * as loginHandler from '../handlers/login'

export default {
    name: 'Register',
    data: () => ({
        drawer: false,
        group: null,
        registration: {
            email: "",
            password: "",
            confirmPassword: ""
        }
    }),
    methods: {
        submit() {
            loginHandler.RegisterUser(this.registration).then(
                (resp) => {
                    if (resp.status == 201) {
                        window.location.href = "#/login";
                    }
                }
            ).catch((error) => console.log(error));
        }
    }
}
</script>