// Canales publicos de contacto: una sola fuente para dock, header y footer.
export const WHATSAPP_NUMBER = "573000000000";
export const INSTAGRAM_URL =
  process.env.NEXT_PUBLIC_INSTAGRAM_URL ?? "https://instagram.com/enlyce_demo";
export const FACEBOOK_URL = process.env.NEXT_PUBLIC_FACEBOOK_URL;

export function whatsappLink(message = "Hola, quiero recibir información sobre los inmuebles de Enlyce Demo."): string {
  return `https://wa.me/${WHATSAPP_NUMBER}?text=${encodeURIComponent(message)}`;
}
