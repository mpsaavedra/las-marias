import { forwardRef } from "react";

// prop-types is a library for typechecking of props
import PropTypes from "prop-types";

// Custom styles for Input
import InputRoot from "./InputRoot";

const Input = forwardRef(({ error, success, disabled, ...rest }, ref) => (
    <InputRoot {...rest} ref={ref} ownerState={{ error, success, disabled }} />
));

// Setting default values for the props of Input
Input.defaultProps = {
    error: false,
    success: false,
    disabled: false,
};

// Typechecking props for the Input
Input.propTypes = {
    error: PropTypes.bool,
    success: PropTypes.bool,
    disabled: PropTypes.bool,
};

export default Input;
