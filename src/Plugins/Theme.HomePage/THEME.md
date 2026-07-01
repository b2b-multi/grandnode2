# Theme.HomePage — Design System

## Color Palette (Material Design 2)

| Token | Hex | Tailwind | Role |
|---|---|---|---|
| Primary | `#4F46E5` | `indigo-600` | Nav, headers, badges, active states |
| Primary Variant | `#3730A3` | `indigo-800` | Testimonials section, hover states |
| Secondary | `#FF5A5F` | `bg-[#FF5A5F]` | All CTA buttons, urgent accents |
| Secondary Variant | `#E04347` | `hover:bg-[#E04347]` | CTA hover/press |
| Background | `#F8FAFC` | `slate-50` | Page canvas |
| Surface | `#FFFFFF` | `white` | Cards, steps, tables |
| On Primary | `#FFFFFF` | `text-white` | Text on indigo backgrounds |
| On Secondary | `#FFFFFF` | `text-white` | Text on coral CTAs |
| On Background | `#0F172A` | `slate-900` | All body copy, headlines |
| On Surface | `#0F172A` | `slate-900` | Text inside cards |
| Error | `#DC2626` | `red-600` | Validation, "Old Way" column |

## Page Sections

1. **Sticky Nav** — transparent → `nav-scrolled` (blurred white) on scroll. Coral "Launch Free" CTA in top-right.
2. **Hero** — Split layout: headline + browser mockup. Primary CTA uses `animate-pulse-soft`.
3. **3-Step Process** — Numbered cards with dashed connector lines. Step 03 uses secondary coral.
4. **Features** — Alternating text/media rows. Visual builder mockup + template thumbnail grid.
5. **Comparison Table** — 3-column pain vs. relief with ❌/✅ icons.
6. **Testimonials** — Dark indigo carousel, auto-rotates every 5s, pauses on hover.
7. **Bottom CTA** — Dark gradient, final registration push.
8. **Footer** — Brand + links.

## Animations (defined in `source.css`)

- `animate-fade-in` — fade + translateY (hero text)
- `animate-slide-in-right` — slide from right (browser mockup)
- `animate-pulse-soft` — gentle scale pulse (primary CTA)

## Typography

| Style | Font | Weight | Desktop | Mobile | Line Ht | Tailwind Classes |
|---|---|---|---|---|---|---|---|
| H1 (Hero) | Plus Jakarta Sans | 800 | 56px | 36px | 1.1 | `font-heading font-extrabold text-[36px] lg:text-[56px] leading-[1.1]` |
| H2 (Section) | Plus Jakarta Sans | 700 | 36px | 28px | 1.2 | `font-heading font-bold text-[28px] lg:text-[36px] leading-[1.2]` |
| H3 (Card) | Plus Jakarta Sans | 600 | 22px | 18px | 1.3 | `font-heading font-semibold text-[18px] lg:text-[22px] leading-[1.3]` |
| Subtitle / Lead | Inter | 500 | 18px | 16px | 1.5 | `font-sans font-medium text-[16px] lg:text-[18px] leading-[1.5]` |
| Body / Tables | Inter | 400 | 16px | 15px | 1.6 | `font-sans text-[15px] lg:text-[16px] leading-[1.6]` |
| Button Text | Plus Jakarta Sans | 600 | 16px | 16px | 1.0 | `font-heading font-semibold text-[16px] leading-[1.0]` |
| Caption | Inter | 400 | 13px | 12px | 1.4 | `font-sans text-[12px] lg:text-[13px] leading-[1.4]` |

**Font Families:**
- `--font-heading`: Plus Jakarta Sans (loaded via Google Fonts w/ weights 600, 700, 800)
- `--font-sans`: Inter (loaded via Google Fonts w/ weights 400, 500, 600, 700, 800, 900)

**Button Case:** Sentence case with arrow (e.g., "Launch your store free →") for higher conversion.

## Build

```bash
npm run build    # rebuild tailwind.css from source.css
npm run watch    # watch mode
```

CSS source: `Content/css/source.css` → compiled output: `Content/css/tailwind.css`
