# Typography System — Landing Page

## Font Pairing

| Role | Font | Why |
|---|---|---|
| Headings & CTAs | **Plus Jakarta Sans** | Punchy, geometric — professional tech-platform vibe |
| Body & UI | **Inter** | Ultra-crisp, highly legible for dense copy |

Loaded via Google Fonts in `_MyLayout.cshtml`:
```
Inter: 400,500,600,700,800,900
Plus Jakarta Sans: 600,700,800
```

Tailwind config (`source.css`):
```
--font-heading: "Plus Jakarta Sans", ui-sans-serif, system-ui, sans-serif;
--font-sans:     "Inter", ui-sans-serif, system-ui, sans-serif;
```

---

## Typography Scale

| Style | Font | Weight | Desktop | Mobile | Line Ht | Tailwind Classes |
|---|---|---|---|---|---|---|
| H1 (Hero Title) | Plus Jakarta Sans | 800 (Extra Bold) | 56px | 36px | 1.1 | `font-heading font-extrabold text-[36px] lg:text-[56px] leading-[1.1]` |
| H2 (Section Heading) | Plus Jakarta Sans | 700 (Bold) | 36px | 28px | 1.2 | `font-heading font-bold text-[28px] lg:text-[36px] leading-[1.2]` |
| H3 (Card / Feature Title) | Plus Jakarta Sans | 600 (Semi Bold) | 22px | 18px | 1.3 | `font-heading font-semibold text-[18px] lg:text-[22px] leading-[1.3]` |
| Subtitle (Lead Copy) | Inter | 500 (Medium) | 18px | 16px | 1.5 | `font-sans font-medium text-[16px] lg:text-[18px] leading-[1.5]` |
| Body Large (Tables/Lists) | Inter | 400 (Regular) | 16px | 15px | 1.6 | `font-sans text-[15px] lg:text-[16px] leading-[1.6]` |
| Button Text | Plus Jakarta Sans | 600 (Semi Bold) | 16px | 16px | 1.0 | `font-heading font-semibold text-[16px] leading-[1.0]` |
| Caption (Microcopy) | Inter | 400 (Regular) | 13px | 12px | 1.4 | `font-sans text-[12px] lg:text-[13px] leading-[1.4]` |

---

## Usage Map

| Element | Style | Example Location |
|---|---|---|
| Hero hook | H1 | "Your E-Commerce Store. Live in 60 Seconds." |
| Section titles | H2 | "From Zero to Selling in 3 Steps", "Why Store Owners Switch" |
| Card titles, testimonial names | H3 | "Claim Your Domain", "Sarah M." |
| Hero subheading, section lead | Subtitle | "No coding. No technical headaches..." |
| Feature explanations, table cells, quotes | Body | Step descriptions, comparison cells, testimonial text |
| CTA buttons | Button | "Launch your store free →", "Create your account now" |
| Badges, footnotes, microcopy | Caption | "Beta — Now Open", "No credit card required" |

## Typography Rules

- **Contrast**: H1/H2 use `text-slate-900 (#0F172A)` against white/off-white backgrounds for maximum readability.
- **Line height**: Large headlines use tighter leading (1.1) to keep multi-line text cohesive. Body copy uses looser leading (1.6) for effortless scanning.
- **Button case**: Sentence case with arrow (→) converts better than rigid all-caps commands.
