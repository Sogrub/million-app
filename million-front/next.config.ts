import type { NextConfig } from "next";
import "./src/env";

const nextConfig: NextConfig = {
  images: {
    unoptimized: true,
  },
};

export default nextConfig;
