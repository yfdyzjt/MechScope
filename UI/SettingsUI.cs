﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework.Graphics;

namespace MechScope.UI
{
    public class SettingsUI : UIState
    {
        public bool Visible = false;
        private UIPanel BasePanel;

        public override void OnInitialize()
        {
            HAlign = 0.5f;
            VAlign = 0.5f;
            Width = new StyleDimension(0, 0.25f);
            Height = new StyleDimension(0, 0);

            BasePanel = new UIPanel();
            BasePanel.MarginLeft = 10;
            BasePanel.MarginRight = 10;
            BasePanel.MarginTop = 10;
            BasePanel.MarginBottom = 10;
            BasePanel.Width = new StyleDimension(0, 1);
            BasePanel.Height = new StyleDimension(0, 1);
            Append(BasePanel);

            UIElement[] elements = new UIElement[]
            {
                null,
                new UIText("Set mode:"),
                new UIToggle("Single", () => SuspendableWireManager.Mode == SuspendableWireManager.SuspendMode.perSingle, () => SuspendableWireManager.Mode = SuspendableWireManager.SuspendMode.perSingle),
                new UIToggle("Wire", () => SuspendableWireManager.Mode == SuspendableWireManager.SuspendMode.perWire, () => SuspendableWireManager.Mode = SuspendableWireManager.SuspendMode.perWire),
                new UIToggle("Source", () => SuspendableWireManager.Mode == SuspendableWireManager.SuspendMode.perSource, () => SuspendableWireManager.Mode = SuspendableWireManager.SuspendMode.perSource),
                new UIToggle("Stage", () => SuspendableWireManager.Mode == SuspendableWireManager.SuspendMode.perStage, () => SuspendableWireManager.Mode = SuspendableWireManager.SuspendMode.perStage),
                null,
                new UIText("Toggle visuals:"),
                new UIToggle("Wire skip", () => VisualizerWorld.ShowWireSkip, () => VisualizerWorld.ShowWireSkip = !VisualizerWorld.ShowWireSkip),
                new UIToggle("Gates done", () => VisualizerWorld.ShowGatesDone, () => VisualizerWorld.ShowGatesDone = !VisualizerWorld.ShowGatesDone),
                new UIToggle("Upcoming gates", () => VisualizerWorld.ShowUpcomingGates, () => VisualizerWorld.ShowUpcomingGates = !VisualizerWorld.ShowUpcomingGates),
                new UIToggle("Triggered lamps", () => VisualizerWorld.ShowTriggeredLamps, () => VisualizerWorld.ShowTriggeredLamps = !VisualizerWorld.ShowTriggeredLamps),
                new UIToggle("Triggered teleporters", () => VisualizerWorld.ShowTeleporters, () => VisualizerWorld.ShowTeleporters = !VisualizerWorld.ShowTeleporters),
                new UIToggle("Triggered pumps", () => VisualizerWorld.ShowPumps, () => VisualizerWorld.ShowPumps = !VisualizerWorld.ShowPumps)
            };

            bool title = false;
            foreach (var item in elements)
            {
                if(item == null)
                {
                    title = true;
                    continue;
                }
                if(title)
                {
                    title = false;
                    AppendToPanel(item, 0);
                }
                else
                {
                    AppendToPanel(item, 20);
                }
                
            }
          
            Height.Pixels += 20;

            Recalculate();
        }

        private void AppendToPanel(UIElement element, float indent)
        {
            BasePanel.Append(element);
            element.Recalculate();
            element.Left = new StyleDimension(indent, 0);
            element.Top = new StyleDimension(Height.Pixels, 0);
            Height.Pixels += element.MinHeight.Pixels + 5;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Visible)
                return;

            base.Draw(spriteBatch);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Main.LocalPlayer.mouseInterface = IsMouseHovering;
            base.DrawSelf(spriteBatch);
        }
    }
}