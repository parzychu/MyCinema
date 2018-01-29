
<template>
    <section class="section">
        <b-tabs>
            <b-tab-item label="Check reservation code">
                <section class="section">
                    <b-field label="Wprowadź kod rezerwacji">
                        <b-input v-model="reservationCode" is-employee="true"></b-input>
                    </b-field>

                    <button class="button is-primary">Odbierz rezerwację</button>
                </section>
            </b-tab-item>

            <b-tab-item label="Dodaj pracownika">
                <section class="section">
                    <div class="columns">
                        <div class="column is-2"></div>
                        <div class="column is-8">
                    Dodaj pracowanika

                    <personal-data-form v-on:submit="registerEmployee">
                    </personal-data-form></div>
                    </div>
                    
                </section>
            </b-tab-item>

            <b-tab-item label="Zarezerwuj bilet">

                <section class="section">
                    <repertoire-preview></repertoire-preview>  
                </section>
            </b-tab-item>
        </b-tabs>
    </section>
</template>

<script>
    import UserPersonalData from 'Components/UserPersonalData.vue';
    import CurrentlyPlayingSection from 'Components/CurrentlyPlayingSection/CurrentlyPlayingSection.vue';
    import RepertoirePreview from 'Components/RepertoirePreview.vue';

    export default {
        name: 'EmployeeProfile',
        components: {
            'personal-data-form': UserPersonalData,
            RepertoirePreview
        },
        created: function () {
        },
        data: function() {
            return {
                employeeFormData: [],
                reservationCode: null
            }
        },
        methods: {
            registerEmployee: function(employeeFormData) {
                axios.post("Auth/Login/RegisterEmployee", {userModel: employeeFormData})
                    .then(res => {
                        // self.$toast.open({
                        //     message: 'Użytkownik został zarejestrowany',
                        //     type: 'is-success'
                        // });
                    });
            },
        }
    }
</script>

<style lang="scss">

</style>
