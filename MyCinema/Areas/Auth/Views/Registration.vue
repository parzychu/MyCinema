<template>
    <section class="section is-fullheight">
        Zarejestruj się

        <personal-data-form v-on:submit="registerUser">
        </personal-data-form>
    </section>
</template>

<script>
    import UserPersonalData from 'Components/UserPersonalData.vue';

    export default {
        name: 'Registration',
        components: {
            'personal-data-form': UserPersonalData
        },
        data: function() {
            return {
                userFormData: []
            }
        },
        methods: {
            onPersonalDataChange: function(userFormData) {
                this.userFormData = UserPersonalData;
                console.log(userFormData)
            },
            registerUser: function(userFormData) {
                var self;

console.log(userFormData)
                axios.post("Auth/Login/Register", {userModel: userFormData})
                    .then(res => {
                        self.$toast.open({
                            message: 'Użytkownik został zarejestrowany',
                            type: 'is-success'
                        });
                    });
            }
        }
    }
</script>

<style>

    .pick-cinema-screen {
            color: gray;
    border: 1px solid gray;
    padding: 2px 0;
    margin: 0 auto;
    width: 500px;
    text-align: center;
    margin-bottom: 50px;
    }

    .pick-cinema-screen.is-taken {
        background-image: repeating-linear-gradient(-45deg,
      transparent,
      transparent 10px,
      gray 10,
      gray 10);
    }
</style>