<template>
    <section class="section">
        <div class="columns">
            <div class="column is-3"></div>
            <div class="column is-6">
                <div class="title is-3">
                    Zarejestruj się</div>

                <personal-data-form v-on:submit="registerUser">
                </personal-data-form>
            </div>
        </div>
    </section>
</template>

<script>
    import UserPersonalData from 'Components/UserPersonalData.vue';

    export default {
        name: 'Registration',
        components: {
            'personal-data-form': UserPersonalData
        },
        data: function () {
            return {
                userFormData: []
            }
        },
        methods: {
            onPersonalDataChange: function (userFormData) {
                this.userFormData = UserPersonalData;
                console.log(userFormData)
            },
            registerUser: function (userFormData) {
                var self;

                console.log(userFormData)
                axios.post("Auth/Login/RegisterClient", {
                        userModel: userFormData
                    })
                    .then(res => {
                        This.$router.push("/Login");
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