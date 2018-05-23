<template>
    <section class="section">
        <b-tabs>
            <b-tab-item label="Historia rezerwacji">
                <section class="section">
                    <b-table :data="res" :striped="true" :hoverable="true" :mobile-cards="true">

                        <template slot-scope="props">

                            <b-table-column label="Tytuł filmu">
                                {{ props.row.movieTitle }}
                            </b-table-column>

                            <b-table-column label="Data seansu" centered>
                                {{ new Date(props.row.date).toLocaleDateString() }} {{ props.row.time }}
                            </b-table-column>
<!-- 
                            <b-table-column label="Kino">
                                {{ props.row.cinema }}
                            </b-table-column> -->


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

                        <template slot="empty">
                            <section class="section">
                                <div class="content has-text-grey has-text-centered">
                                    <p>
                                        <b-icon icon="emoticon-sad" size="is-large">
                                        </b-icon>
                                    </p>
                                    <p>Nothing here.</p>
                                </div>
                            </section>
                        </template>
                    </b-table>
                </section>
            </b-tab-item>

            <b-tab-item label="Profil">
                <section class="section">
                    <div class="columns">
                        <div class="column is-2">
                        </div>
                        <div class="column">
                            Dodaj pracownika
                            <personal-data-form v-on:submit="registerEmployee">
                            </personal-data-form>
                        </div>
                        <div class="column is-2">
                        </div>
                    </div>
                </section>
            </b-tab-item>
        </b-tabs>
    </section>
</template>

<script>
    import RepertoirePreview from 'Components/RepertoirePreview.vue';
    import UserPersonalData from 'Components/UserPersonalData.vue';

    export default {
        name: 'UserProfile',
        components: {
            'personal-data-form': UserPersonalData,
            'repertoire-preview': RepertoirePreview
        },
        created: function () {
            this.getReservations()
        },
        data: function () {
            return {
                employeeFormData: [],
                res: []
            }
        },
        methods: {
            registerEmployee: function (employeeFormData) {
                this.employeeFormData = UserPersonalData;
                console.log(employeeFormData)
            },
            getReservations: function () {
                axios.post("Reservation/Reservation/GetUserReservations")
                    .then((res) => this.res = res.data);
            }
        }
    }
</script>

<style lang="scss">

</style>