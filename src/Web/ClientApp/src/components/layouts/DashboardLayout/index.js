import { useEffect } from "react";
import { useLocation } from "react-router-dom";
import PropTypes from "prop-types";
import Box from "../../Box";

import { useApplicationUIController, setLayout } from "../../../context";

function DashboardLayout({ children }) {
    const [controller, dispatch] = useApplicationUIController();
    const { pathname } = useLocation();

    useEffect(() => {
        setLayout(dispatch, "dashboard");
    }, [pathname]);

    return (
        <Box
            sx={({breakpoints, transitions, functions: { pxToRem }}) => ({
                p: 3,
                position: "relative",
                [breakpoints.up("x1")]: {
                    marginLeft: pxToRem(274),
                    transition: transitions.create(["margin-left", "margin-right"], {
                        easing: transitions.easing.easingInOut,
                        duration: transitions.duration.standard,
                    }),
                },
            })}
        >
            {children}
        </Box>
    );
}

export default DashboardLayout;