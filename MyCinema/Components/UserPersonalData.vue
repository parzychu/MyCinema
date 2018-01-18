<template>
    <form v-on:submit.prevent="onSubmit">
        <b-field label="Imię i nazwisko">
            <b-input value="Kevin Garvey"
                v-model="userName"></b-input>
        </b-field>

        <b-field label="Email"
            type="is-danger"
            message="This email is invalid">
            <b-input type="email"
                value="john@"
                maxlength="30">
            </b-input>
        </b-field>

        <b-field label="Nazwa użytkownika"
            type="is-success"
            message="This username is available">
            <b-input value="johnsilver" maxlength="30"></b-input>
        </b-field>

        <b-field label="Hasło"
            type="is-warning"
            :message="['Password is too short', 'Password must have at least 8 characters']">
            <b-input v-model="password" type="password" maxlength="30"></b-input>
        </b-field>

        <b-field label="Potwierdź hasło"
            type="is-warning"
            :message="['Password is too short', 'Password must have at least 8 characters']">
            <b-input v-model="confirmPassword" type="password" maxlength="30"></b-input>
        </b-field>

        <b-field label="Subject">
            <b-select placeholder="Select a subject">
                <option value="1">Option 1</option>
                <option value="2">Option 2</option>
            </b-select>
        </b-field>

        <input type="submit" class="button" text="Zarejestruj">
    </form>
</template>

<script>

    export default {
        name: 'UserPersonalData',
        data: function () {
            return {
                userName: 'Maczek Smaczek',
                password: 'TestTest123',
                confirmPassword: 'TestTest123'
            }
        },
        created: function () {
            
        },
        methods: {
            onSubmit() {

                this.$emit('submit', {
                    userName: this.userName,
                    password: this.password,
                    confirmPassword: this.confirmPassword
                });
            }
        }
    }
</script>

<style lang="scss">
    @import "Styles/Variables";

    .bg-poster {
        width: 100%;
    }
</style>