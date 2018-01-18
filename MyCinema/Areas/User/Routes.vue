
<script>
    import ClientProfile from './Views/ClientProfile.vue';
    import EmployeeProfile from './Views/EmployeeProfile.vue';

    export default [
        { name: 'UserProfile', path: '/User', component: ClientProfile },
        { name: 'EmployeeProfile', path: '/Employee', component: EmployeeProfile }
    ]
</script>