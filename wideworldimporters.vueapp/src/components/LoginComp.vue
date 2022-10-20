<template>
    <v-form>
        <v-container class="px-16 mt-10">
            <ValidationProvider name="Email" rules="required" v-slot="{ errors }">
                <v-text-field v-model="user.email" label="Filled" placeholder="Email" name="email" filled rounded dense>
                </v-text-field>
                <v-alert v-if="errors[0]" dense outlined type="error">
                    {{ errors[0]}}
                </v-alert>
            </ValidationProvider>

            <ValidationProvider name="Contraseña" rules="required" v-slot="{ errors }">
                <v-text-field v-model="user.password" :type="'password'" label="Filled" name="password"
                    placeholder="Password" filled rounded dense></v-text-field>
                <v-alert v-if="errors[0]" dense outlined type="error">
                    {{ errors[0]}}
                </v-alert>
            </ValidationProvider>

            <!--<v-alert v-if="message" border="right" colored-border type="error" elevation="2">
                Complete todos los campos!
            </v-alert>-->
        </v-container>
    </v-form>
</template>
<script>
import User from '../models/user'
import { ValidationProvider } from 'vee-validate'

export default {
    name: 'LoginComp',
    components: {
        ValidationProvider
    },
    data() {
        return {
            user: new User(),
            message: ''
        }
    },
    computed: {
        loggedIn() {
            return this.$store.state.auth.loggedIn;
        }
    },
    created() {
        if (this.loggedIn) {
            this.$router.push('/home');
        }
    },
    methods: {
        handleLogin() {
            this.$validator.validateAll().then(isValid => {
                if (!isValid) {
                    return;
                }
                if (this.user.email && this.user.password) {
                    this.$store.dispatch('auth/login', this.user).then(
                        () => {
                            this.$router.push('/profile');
                        },
                        error => {
                            this.message = (error.response && error.response.data) || error.message || error.toString();
                        }
                    );
                }
            });
        }
    }
}
</script>