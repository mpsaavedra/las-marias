// eslint-disable-next-line
import Grid from "@mui/material/Grid";
import MDBox from "../../components/Box";
import DashboardLayout from "../../components/layouts/DashboardLayout";
import Footer from "../../components/Footer";

function Dashboard() {
    return (
        <DashboardLayout>
            <MDBox py={3}>
                content
            </MDBox>
            <Footer />
        </DashboardLayout>
    );
}

export default Dashboard;