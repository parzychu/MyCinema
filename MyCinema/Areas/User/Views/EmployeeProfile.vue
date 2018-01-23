
<template>
    <section class="section">
        <b-tabs>
            <b-tab-item label="Check reservation code">

                <b-field label="Wprowadź kod rezerwacji">
                    <b-input v-model="reservationCode" is-employee="true"></b-input>
                </b-field>

                <button class="button is-primary">Odbierz rezerwację</button>
            </b-tab-item>

            <b-tab-item label="Dodaj pracownika">
                Dodaj pracowanika

                <personal-data-form v-on:submit="registerEmployee">
                </personal-data-form>
            </b-tab-item>

            <b-tab-item label="Zarezerwuj bilet">
                <repertoire-preview></repertoire-preview>  
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
                this.employeeFormData = employeeFormData;
                console.log(employeeFormData)
            },
        }
    }
</script>

<style lang="scss">

</style>
