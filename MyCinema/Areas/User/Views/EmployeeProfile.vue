
<template>
    <section class="section">
        <b-tabs>
            <b-tab-item label="Sprawdź rezerwację">
                <section class="section">
                    <b-field label="Wprowadź nazwę użytkownika" :type="reservationCodeType" :message="reservationCodeMessage">
                        <b-input v-model="reservationCode"  is-employee="true"
                        @input="reservationCodeMessage = ''; reservationCodeType = ''"></b-input>
                    </b-field>

                    <button class="button is-primary" @click="checkReservation()">Odbierz rezerwację</button>
                </section>

                <b-table :data="res" :striped="true" :hoverable="true" :mobile-cards="true">

                        <template slot-scope="props">

                            <b-table-column label="Tytuł filmu">
                                {{ props.row.movieTitle }}
                            </b-table-column>

                            <b-table-column label="Data seansu" centered>
                                {{ new Date(props.row.date).toLocaleDateString() }} {{ props.row.time }}
                            </b-table-column>



                            <b-table-column label="Siedzenia">
                                <div v-for="row in props.row.seats">
                                    <span>Rząd: {{row[0].row}}</span>
                                    <span>Miejsca:</span>
                                    <span v-for="seat in row">{{seat.column}},&nbsp;</span>
                                </div>
                            </b-table-column>
                            <b-table-column>
                                <button class="button is-primary">Pokaż szczegóły</button>
                            </b-table-column>
                        </template>

                    </b-table>
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
                res: [],
                employeeFormData: [],
                reservationCode: null,
                reservationCodeMessage: "",
                reservationCodeType: ''
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

            checkReservation: function() {
                axios.post("User/User/GetUserReservations", {userName: this.reservationCode})
                    .then((res) => this.res = res.data)
                    .catch((err) => { 
                        
                    this.reservationCodeMessage = "Nie znaleziono podanego użytkownika";
                    this.reservationCodeType = "is-danger";});
            }
        }
    }
</script>

<style lang="scss">

</style>
