
<template>
    <div>
        <b-tabs v-model="activeTab">
            <b-tab-item label="Historia rezerwacji">

            </b-tab-item>

            <b-tab-item label="Profil">
                Dodaj pracowanika

                <personal-data-form v-on:submit="registerEmployee">
                </personal-data-form>
            </b-tab-item>
        </b-tabs>
    </div>
</template>

<script>
    import RepertoirePreview from 'Components/RepertoirePreview.vue';
    import UserPersonalData from 'Components/UserPersonalData.vue';

    export default {
        name: 'UserProfile',
        components: {
            'personal-data-form': UserPersonalData,
            RepertoirePreview
        },
        created: function () {
        },
        data: function() {
            return {
                employeeFormData: []
            }
        },
        methods: {
            registerEmployee: function(employeeFormData) {
                this.employeeFormData = UserPersonalData;
                console.log(employeeFormData)
            },
        }
    }
</script>

<style lang="scss">

</style>
