<template>
    <form v-on:submit.prevent="onSubmit">
        <b-field grouped>
            <b-field label="Imię">
            <b-input
                ></b-input>
        </b-field>

        <b-field label="Nazwisko">
            <b-input
                ></b-input>
        </b-field>

        </b-field>
        
        <b-field label="Nazwa użytkownika">
            <b-input
                v-model="userName"
                maxlength="30"></b-input>
        </b-field>

        <b-field label="Email">
            <b-input type="email"
                v-model="email"
                maxlength="30">
            </b-input>
        </b-field>

        <b-field label="Telefon">
            <b-input
                v-model="phone"></b-input>
        </b-field>

        <b-field label="Hasło">
            <b-input v-model="password" type="password"></b-input>
        </b-field>

        <b-field label="Potwierdź hasło">
            <b-input v-model="confirmPassword" type="password"></b-input>
        </b-field>

        <input type="submit" class="button reservation-btn-next" text="Zarejestruj">
    </form>
</template>

<script>

    export default {
        name: 'UserPersonalData',
        data: function () {
            return {
                userName: '',
                password: '',
                confirmPassword: '',
                email: '', 
                phone: ''
            }
        },
        created: function () {
            
        },
        methods: {
            onSubmit() {

                this.$emit('submit', {
                    userName: this.userName,
                    email: this.email,
                    password: this.password,
                    phoneNumber: this.phone, 
                    confirmPassword: this.confirmPassword
                });
            }
        }
    }
</script>

<style lang="scss">
    

    .bg-poster {
        width: 100%;
    }
</style>