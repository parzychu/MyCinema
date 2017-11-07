<template>
    <section class="section is-fullheight my-pick-cinema">
        <div class="section-title">
            <h2 class="title is-2">Log in</h2>
        </div>
        <div class="section-body">
            <div class="column is-6 is-offset-3"> 
                <div class="field">
                    <p class="control has-icons-left has-icons-right">
                        <input class="input is-medium" type="email" placeholder="Email">
                        <span class="icon is-medium is-left">
      <i class="fa fa-envelope"></i>
    </span>
                        <span class="icon is-medium is-right">
      <i class="fa fa-check"></i>
    </span>
                    </p>
                </div>
                <div class="field">
                    <p class="control has-icons-left">
                        <input class="input is-medium" type="password" placeholder="Password">
                        <span class="icon is-medium is-left">
      <i class="fa fa-lock"></i>
    </span>
                    </p>
                </div>
                <router-link :to="{name: 'PickSeats'}" class="button is-primary is-medium">
                    Dalej
                </router-link>
                
                </div>
        </div>
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