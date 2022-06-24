// base styles
import borders from "../../base/borders";

// helper functions
import pxToRem from "../../functions/pxToRem";

const { borderRadius } = borders;

const props = {
  styleOverrides: {
    root: {
      display: "block",
      padding: `${pxToRem(16)} ${pxToRem(16)} 0  ${pxToRem(16)}`,
      borderRadius: `${borderRadius.xl} ${borderRadius.xl} 0 0`,
    },
  },
};

export default props;