<template>
    <v-container grid-list-xs>
        <form>
            <v-text-field v-model="login.email" label="E-mail" required></v-text-field>
            <v-text-field v-model="login.password" label="Password" type="password" required>
            </v-text-field>
            <v-btn class="mr-4" @click="submit">
                submit
            </v-btn>
        </form>
    </v-container>

</template>

<script>
import * as loginHandler from '../handlers/login'

export default {
    name: 'LoginComponent',
    data: () => ({
        drawer: false,
        group: null,
        login: {
            email: "",
            password: ""
        }
    }),
    methods: {
        submit() {
            loginHandler.SendLoginData(this.login).then(
                (resp) => {
                    if (resp.status == 200) {
                        window.location.href = "/";
                    }
                }
            ).catch((error) => console.log(error));
        }
    }
}
</script>