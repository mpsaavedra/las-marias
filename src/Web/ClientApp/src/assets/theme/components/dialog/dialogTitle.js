// base styles
import typography from "../../base/typography";

// helper functions
import pxToRem from "../../functions/pxToRem";

const { size } = typography;

const props = {
  styleOverrides: {
    root: {
      padding: pxToRem(16),
      fontSize: size.xl,
    },
  },
};
export default props;