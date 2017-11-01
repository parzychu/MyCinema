<template>
    <section class="section">
        <div class="field">
            <p class="control has-icons-left has-icons-right">
                <input class="input" type="email" placeholder="Email">
                <span class="icon is-small is-left">
      <i class="fa fa-envelope"></i>
    </span>
                <span class="icon is-small is-right">
      <i class="fa fa-check"></i>
    </span>
            </p>
        </div>
        <div class="field">
            <p class="control has-icons-left">
                <input class="input" type="password" placeholder="Password">
                <span class="icon is-small is-left">
      <i class="fa fa-lock"></i>
    </span>
            </p>
        </div>
        <router-link :to="{name: 'PickSeats'}" class="button is-primary">
            Dalej
        </router-link>
    </section>
</template>

<script>
    export default {
        name: 'LogInPage',
        data() {
            return {
                movies: []
            }
        },
        created: function () {
            axios.post("Reservation/Reservation/GetMovies")
                .then((res) => {
                    this.movies = res.data;
                }).catch((e) => {
                    console.error(e);
                });
        }
    }
</script>

<style>
    /* @import 'bulma/css/bulma.css'; */
</style>