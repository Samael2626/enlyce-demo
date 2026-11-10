import type { Metadata } from "next";
import { BrochureBook } from "@/components/BrochureBook";

export const metadata: Metadata = {
  title: "Brochure institucional",
  description: "Recorre el brochure interactivo de Enlyce Demo.",
};

export default function BrochurePage() {
  return (
    <div className="brochure-page">
      <h1 className="sr-only">Brochure institucional de Enlyce Demo</h1>
      <BrochureBook />
    </div>
  );
}
